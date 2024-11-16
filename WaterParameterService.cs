using KoiManagementSystem.Models;
using KoiManagementSystem.Repositories;

namespace KoiManagementSystem.Services
{
    public class WaterParameterService : IWaterParameterService
    {
        private readonly IWaterParameterRepository _waterParameterRepository;

        public WaterParameterService(IWaterParameterRepository waterParameterRepository)
        {
            _waterParameterRepository = waterParameterRepository;
        }

        public IEnumerable<WaterParameter> GetAllWaterParameters() => _waterParameterRepository.GetAll();

        public WaterParameter GetWaterParameterById(int id) => _waterParameterRepository.GetById(id);

        public void AddWaterParameter(WaterParameter waterParameter) => _waterParameterRepository.Add(waterParameter);

        public void UpdateWaterParameter(WaterParameter waterParameter) => _waterParameterRepository.Update(waterParameter);

        public void DeleteWaterParameter(int id) => _waterParameterRepository.Delete(id);
    }
}