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
