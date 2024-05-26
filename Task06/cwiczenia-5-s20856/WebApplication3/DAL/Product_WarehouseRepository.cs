using System.Data.Common;
using System.Data.SqlClient;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.DAL
{


    public interface IProductWarehouseRepository
    {

        Task<int> PostWarehouse(Product_Warehouse product_Warehouse);
        Task<int> PostWarehouseAsync(int IdProduct, int IdWarehouse, int Amount, DateTime CreatedAt);


    }
    public class Product_WarehouseRepository : IProductWarehouseRepository
    {

        public async Task<int> PostWarehouse(Product_Warehouse product_Warehouse)
        {
            string connectionString = "Data Source=db-mssql;Initial Catalog=s20856;Integrated Security=True";

            if (product_Warehouse == null) throw new ArgumentNullException(nameof(product_Warehouse));

            using SqlConnection connection = new SqlConnection();

            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT count(Price) as 'ProductCount' FROM Product WHERE IdProduct = @IdProduct;";

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@IdProduct", product_Warehouse.IdProduct);
            command.Connection = connection;

            await connection.OpenAsync();

            var checkProduct = 0;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    checkProduct = (int)reader["ProductCount"];
                }
            }

            if (checkProduct == 0)
                return 1;

            command.Parameters.Clear();
            command.CommandText = "SELECT count(IdWarehouse) as 'WarehouseCount' FROM Warehouse WHERE IdWarehouse = @IdWarehouse;";
            command.Parameters.AddWithValue("@IdWarehouse", product_Warehouse.IdWarehouse);


            var checkWarehouse = 0;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    checkWarehouse = (int)reader["WarehouseCount"];
                }
            }


            if (checkWarehouse == 0)
                return 2;

            command.Parameters.Clear();
            command.CommandText = "SELECT IdOrder FROM \"Order\" WHERE IdProduct = @IdProduct and Amount = @Amount and CreatedAt < @CreatedAt;";
            command.Parameters.AddWithValue("@IdProduct", product_Warehouse.IdProduct);
            command.Parameters.AddWithValue("@Amount", product_Warehouse.Amount);
            command.Parameters.AddWithValue("@CreatedAt", product_Warehouse.CreatedAt);

            var idOrder = 0;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    idOrder = (int)reader["IdOrder"];
                }
            }


            if (idOrder == 0) return 3;

            command.Parameters.Clear();
            command.CommandText = "SELECT count(*) as 'Number' FROM Product_Warehouse WHERE IdOrder = (SELECT IdOrder FROM \"Order\" WHERE IdProduct = @IdProduct and Amount = @Amount and CreatedAt < @CreatedAt);";
            command.Parameters.AddWithValue("@IdProduct", product_Warehouse.IdProduct);
            command.Parameters.AddWithValue("@Amount", product_Warehouse.Amount);
            command.Parameters.AddWithValue("@CreatedAt", product_Warehouse.CreatedAt);

            var checkOrder = 0;

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    checkOrder = (int)reader["Number"];
                }
            }

            if (checkOrder != 0) return 4;


            command.Parameters.Clear();
            DbTransaction tran = await connection.BeginTransactionAsync();
            command.Transaction = (SqlTransaction)tran;

            try
            {
                command.CommandText = "UPDATE \"Order\" SET FulfilledAt = @CreatedAt WHERE IdOrder = @IdOrder";
                command.Parameters.AddWithValue("IdOrder", idOrder);
                command.Parameters.AddWithValue("@CreatedAt", product_Warehouse.CreatedAt);

                var a = await command.ExecuteNonQueryAsync();
                Console.WriteLine(a);

                if (a == 0) throw new Exception("Error");

                command.Parameters.Clear();
                command.CommandText = "INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) VALUES(@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Amount * @Price, @CreatedAt); ";
                command.Parameters.AddWithValue("@IdProduct", product_Warehouse.IdProduct);
                command.Parameters.AddWithValue("@IdWarehouse", product_Warehouse.IdWarehouse);
                command.Parameters.AddWithValue("@Amount", product_Warehouse.Amount);
                command.Parameters.AddWithValue("@IdOrder", idOrder);
                command.Parameters.AddWithValue("@Price", checkProduct);
                command.Parameters.AddWithValue("@CreatedAt", product_Warehouse.CreatedAt);

                if (await command.ExecuteNonQueryAsync() == 0) throw new Exception("Error");

                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new ArgumentException(e.Message);
            }

            return 0;
        }


        public async Task<int> PostWarehouseAsync(int IdProduct, int IdWarehouse, int Amount, DateTime CreatedAt) {

            using SqlConnection connection = new SqlConnection();

            string connectionString = "Data Source=db-mssql;Initial Catalog=s20856;Integrated Security=True";

            connection.ConnectionString = connectionString;

            using SqlCommand command = new SqlCommand("AddProductToWarehouse", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdProduct", IdProduct);
            command.Parameters.AddWithValue("@IdWarehouse", IdWarehouse);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            command.Connection = connection;

            await connection.OpenAsync();
            var tran = connection.BeginTransaction();
            command.Transaction = tran;

            SqlDataReader dr = await command.ExecuteReaderAsync();
            int returnId = 0;
            using (dr)
            {
                while (await dr.ReadAsync())
                {
                    returnId = Decimal.ToInt32((decimal)dr["NewId"]);
                }
            }
            await tran.CommitAsync();

            return returnId;
        }
    }
}

