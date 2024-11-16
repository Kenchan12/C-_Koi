using KoiManagementSystem.Models;
using KoiManagementSystem.Repositories;

namespace KoiManagementSystem.Services
{
    public class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepository _koiFishRepository;

        public KoiFishService(IKoiFishRepository koiFishRepository)
        {
            _koiFishRepository = koiFishRepository;
        }

        public IEnumerable<KoiFish> GetAllKoiFishes() => _koiFishRepository.GetAll();

        public KoiFish GetKoiFishById(int id) => _koiFishRepository.GetById(id);

        public void AddKoiFish(KoiFish koiFish) => _koiFishRepository.Add(koiFish);

        public void UpdateKoiFish(KoiFish koiFish) => _koiFishRepository.Update(koiFish);

        public void DeleteKoiFish(int id) => _koiFishRepository.Delete(id);
    }
}