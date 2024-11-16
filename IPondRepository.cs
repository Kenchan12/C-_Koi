using KoiManagementSystem.Models;

namespace KoiManagementSystem.Repositories
{
    public interface IPondRepository
    {
        IEnumerable<Pond> GetAll();
        Pond GetById(int id);
        void Add(Pond pond);
        void Update(Pond pond);
        void Delete(int id);
    }
}