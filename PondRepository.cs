using KoiManagementSystem.Data;
using KoiManagementSystem.Models;

namespace KoiManagementSystem.Repositories
{
    public class PondRepository : IPondRepository
    {
        private readonly KoiManagementContext _context;

        public PondRepository(KoiManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Pond> GetAll() => _context.Ponds.ToList();

        public Pond GetById(int id) => _context.Ponds.Find(id);

        public void Add(Pond pond)
        {
            _context.Ponds.Add(pond);
            _context.SaveChanges();
        }

        public void Update(Pond pond)
        {
            _context.Ponds.Update(pond);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var pond = _context.Ponds.Find(id);
            if (pond != null)
            {
                _context.Ponds.Remove(pond);
                _context.SaveChanges();
            }
        }
    }
}