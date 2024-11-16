using KoiManagementSystem.Models;
using KoiManagementSystem.Repositories;

namespace KoiManagementSystem.Services
{
    public class PondService : IPondService
    {
        private readonly IPondRepository _pondRepository;

        public PondService(IPondRepository pondRepository)
        {
            _pondRepository = pondRepository;
        }

        public IEnumerable<Pond> GetAllPonds() => _pondRepository.GetAll();

        public Pond GetPondById(int id) => _pondRepository.GetById(id);

        public void AddPond(Pond pond) => _pondRepository.Add(pond);

        public void UpdatePond(Pond pond) => _pondRepository.Update(pond);

        public void DeletePond(int id) => _pondRepository.Delete(id);

      
    }
}