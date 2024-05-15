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
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
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
            throw new NotImplementedException();
        }

        public int DeleteAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public int UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
