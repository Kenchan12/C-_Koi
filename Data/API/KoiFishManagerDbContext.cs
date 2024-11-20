using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KoiFishManager.Api.Entities;

namespace KoiFishManager.Api.Data
{
    public class KoiFishManagerDbContext : IdentityDbContext<User, Role, Guid>
    {
        public KoiFishManagerDbContext(DbContextOptions<KoiFishManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Pond> Ponds { get; set; }
        public DbSet<KoiFish> KoiFishes { get; set; }
        public DbSet<PondStatus> PondStatuses { get; set; }
        public DbSet<FeedingSchedule> FeedingSchedules { get; set; }

    }
}
