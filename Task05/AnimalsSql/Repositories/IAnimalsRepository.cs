using AnimalsSql.Models;

namespace AnimalsSql.Repositories
{
    public interface IAnimalsRepository
    {
        IEnumerable<Animal> GetAnimals();

        int CreateAnimal(Animal animal);

        int UpdateAnimal(Animal animal);

        int DeleteAnimal(Animal animal);



    }
}
