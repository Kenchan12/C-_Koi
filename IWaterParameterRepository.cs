using KoiManagementSystem.Models;

namespace KoiManagementSystem.Repositories
{
    public interface IWaterParameterRepository
    {
        IEnumerable<WaterParameter> GetAll();
        WaterParameter GetById(int id);
        void Add(WaterParameter waterParameter);
        void Update(WaterParameter waterParameter);
        void Delete(int id);
    }
}