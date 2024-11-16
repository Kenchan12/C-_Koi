using Microsoft.EntityFrameworkCore;
using KoiManagementSystem.Models;
using System.Collections.Generic;

namespace KoiManagementSystem.Data
{
    public class KoiManagementContext : DbContext
    {
        public KoiManagementContext(DbContextOptions<KoiManagementContext> options) : base(options) { }

        public DbSet<Pond> Ponds { get; set; }
        public DbSet<KoiFish> KoiFishes { get; set; }
        public DbSet<WaterParameter> WaterParameters { get; set; }
    }
}