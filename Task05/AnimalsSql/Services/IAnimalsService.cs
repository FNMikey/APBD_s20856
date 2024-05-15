using AnimalsSql.Models;

namespace AnimalsSql.Services
{
    public interface IAnimalsService
    {
        IEnumerable<Animal> GetAnimals();

        int CreateAnimal(Animal animal);

        int UpdateAnimal(Animal animal);

        int DeleteAnimal(Animal animal);

    }
}
