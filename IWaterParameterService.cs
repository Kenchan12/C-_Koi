using KoiManagementSystem.Models;

namespace KoiManagementSystem.Services
{
    public interface IWaterParameterService
    {
        IEnumerable<WaterParameter> GetAllWaterParameters();
        WaterParameter GetWaterParameterById(int id);
        void AddWaterParameter(WaterParameter waterParameter);
        void UpdateWaterParameter(WaterParameter waterParameter);
        void DeleteWaterParameter(int id);
    }
}