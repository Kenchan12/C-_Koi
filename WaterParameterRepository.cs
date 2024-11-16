using KoiManagementSystem.Data;
using KoiManagementSystem.Models;

namespace KoiManagementSystem.Repositories
{
    public class WaterParameterRepository : IWaterParameterRepository
    {
        private readonly KoiManagementContext _context;

        public WaterParameterRepository(KoiManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<WaterParameter> GetAll() => _context.WaterParameters.ToList();

        public WaterParameter GetById(int id) => _context.WaterParameters.Find(id);

        public void Add(WaterParameter waterParameter)
        {
            _context.WaterParameters.Add(waterParameter);
            _context.SaveChanges();
        }

        public void Update(WaterParameter waterParameter)
        {
            _context.WaterParameters.Update(waterParameter);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var waterParameter = _context.WaterParameters.Find(id);
            if (waterParameter != null)
            {
                _context.WaterParameters.Remove(waterParameter);
                _context.SaveChanges();
            }
        }
    }
}