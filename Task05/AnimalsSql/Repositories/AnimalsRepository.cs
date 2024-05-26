using AnimalsSql.Models;
using System.Data.SqlClient;

namespace AnimalsSql.Repositories
{
    public class AnimalsRepository : IAnimalsRepository
    {

        private IConfiguration _configuration;

        public AnimalsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            
            using var con = new SqlConnection(_configuration["Data Source=localhost; Database=APBD5; Initial Catalog=s20856;Integrated Security=True"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY Name";

            var dr = cmd.ExecuteReader();
            var animals = new List<Animal>();
            while (dr.Read())
            {
                var animal = new Animal
                {
                    IdAnimal = (int)dr["IdAnimal"],
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString()
                };
                animals.Add(animal);
            }

            return animals;
        }

        public int CreateAnimal(Animal animal)
        {
            using var con = new SqlConnection(_configuration["Data Source=localhost; Database=APBD5; Initial Catalog=s20856;Integrated Security=True"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Animals.Animal(Name, Description, Category, Area) VALUES(@Name, @Description, @Category, @Area)";
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            if (animal.Description == null)
                animal.Description = "";
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }

        public int DeleteAnimal(int IdAnimal)
        {
            using var con = new SqlConnection(_configuration["Data Source=localhost; Database=APBD5; Initial Catalog=s20856;Integrated Security=True"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Animals.Animal WHERE IdAnimal = @IdAnimal";
            cmd.Parameters.AddWithValue("@IdAnimal", IdAnimal);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }

        public int UpdateAnimal(Animal animal, int IdAnimal)
        {
            using var con = new SqlConnection(_configuration["Data Source=localhost; Database=APBD5; Initial Catalog=s20856;Integrated Security=True"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Animals.Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            if (animal.Description == null)
                animal.Description = "";
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);
            cmd.Parameters.AddWithValue("@IdAnimal", IdAnimal);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }
    }
}
