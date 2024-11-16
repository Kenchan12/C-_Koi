using KoiManagementSystem.Models;
using KoiManagementSystem.Services;


namespace KoiManagementSystem.Services
{
    public interface IPondService
    {
        IEnumerable<Pond> GetAllPonds();
        Pond GetPondById(int id);
        void AddPond(Pond pond);
        void UpdatePond(Pond pond);
        void DeletePond(int id);
    }
}