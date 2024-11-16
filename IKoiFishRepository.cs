using KoiManagementSystem.Models;

namespace KoiManagementSystem.Repositories
{
    public interface IKoiFishRepository
    {
        IEnumerable<KoiFish> GetAll();
        KoiFish GetById(int id);
        void Add(KoiFish koiFish);
        void Update(KoiFish koiFish);
        void Delete(int id);
    }
}