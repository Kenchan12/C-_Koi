using KoiManagementSystem.Models;

namespace KoiManagementSystem.Services
{
    public interface IKoiFishService
    {
        IEnumerable<KoiFish> GetAllKoiFishes();
        KoiFish GetKoiFishById(int id);
        void AddKoiFish(KoiFish koiFish);
        void UpdateKoiFish(KoiFish koiFish);
        void DeleteKoiFish(int id);
    }
}