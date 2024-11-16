using KoiManagementSystem.Data;
using KoiManagementSystem.Models;

namespace KoiManagementSystem.Repositories
{
    public class KoiFishRepository : IKoiFishRepository
    {
        private readonly KoiManagementContext _context;

        public KoiFishRepository(KoiManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<KoiFish> GetAll() => _context.KoiFishes.ToList();

        public KoiFish GetById(int id) => _context.KoiFishes.Find(id);

        public void Add(KoiFish koiFish)
        {
            _context.KoiFishes.Add(koiFish);
            _context.SaveChanges();
        }

        public void Update(KoiFish koiFish)
        {
            _context.KoiFishes.Update(koiFish);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var koiFish = _context.KoiFishes.Find(id);
            if (koiFish != null)
            {
                _context.KoiFishes.Remove(koiFish);
                _context.SaveChanges();
            }
        }
    }
}