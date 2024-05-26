using AnimalsSql.Models;
using AnimalsSql.Repositories;

namespace AnimalsSql.Services
{
    public class AnimalsService : IAnimalsService
    {

        private readonly IAnimalsRepository _animalsRepository;

        public AnimalsService(IAnimalsRepository animalsRepository)
        {
            _animalsRepository = animalsRepository;
        }


        public IEnumerable<Animal> GetAnimals()
        {
            return _animalsRepository.GetAnimals();
        }



        public int CreateAnimal(Animal animal)
        {
            return _animalsRepository.CreateAnimal(animal);
        }

        public int DeleteAnimal(int IdAnimal)
        {
            return _animalsRepository.DeleteAnimal(IdAnimal);
        }

        public int UpdateAnimal(Animal animal, int IdAnimal)
        {
            return _animalsRepository.UpdateAnimal(animal,IdAnimal);
        }
    }
}
