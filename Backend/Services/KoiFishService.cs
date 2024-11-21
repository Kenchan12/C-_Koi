using KoiFishManager.Api.Data;
using KoiFishManager.Api.Entities;
using KoiFishManager.Models.KoiFish;
using KoiFishManager.Models.Pond;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace KoiFishManager.API.Services
{
    public class KoiFishService : IKoiFishService
    {
        private readonly KoiFishManagerDbContext _context;

        public KoiFishService(KoiFishManagerDbContext context)
        {
            _context = context;
        }

        public async Task<KoiFishResponse> AddAsync(int pondId, KoiFishRequest request)
        {
            var koiFish = new KoiFish
            {
                Name = request.Name,
                Color = request.Color,
                Size = request.Size,
                Origin = request.Origin,
                HealthStatus = request.HealthStatus,
                PondId = pondId
            };

          
            _context.KoiFishes.Add(koiFish);
            await _context.SaveChangesAsync();

           
            return new KoiFishResponse
            {
                Id = koiFish.Id,
                Name = koiFish.Name,
                Color = koiFish.Color,
                Size = koiFish.Size,
                Origin = koiFish.Origin,
                HealthStatus = koiFish.HealthStatus,
                PondId = koiFish.PondId
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var koiFish = await _context.KoiFishes.FindAsync(id); 
            if (koiFish == null)
            {
                return false;
            }

            _context.KoiFishes.Remove(koiFish); 
            await _context.SaveChangesAsync(); 
            return true; 
        }

        public async Task<List<KoiFishResponse>> GetAllByUserIdAsync(Guid userId)
        {

           
            var koiFishes = await _context.Ponds
                .Where(p => p.UserId == userId) 
                .SelectMany(p => p.KoiFishes)  
                .ToListAsync();

         
            return koiFishes.Select(koiFish => new KoiFishResponse
            {
                Id = koiFish.Id,
                Name = koiFish.Name,
                Color = koiFish.Color,
                Size = koiFish.Size,
                Origin = koiFish.Origin,
                HealthStatus = koiFish.HealthStatus,
                CreatedAt = koiFish.CreatedAt,
                PondId = koiFish.PondId
            }).ToList();
        }

        public async Task<KoiFishDetailResponse> GetByIdAsync(int id)
        {
           
            var koiFish = await _context.KoiFishes.Include(p => p.Pond)
                .FirstOrDefaultAsync(k => k.Id == id);

            if (koiFish == null)
            {
                return null;
            }

          
            return new KoiFishDetailResponse
            {
                Id = koiFish.Id,
                Name = koiFish.Name,
                Color = koiFish.Color,
                Size = koiFish.Size,
                Origin = koiFish.Origin,
                HealthStatus = koiFish.HealthStatus,
                PondId = koiFish.PondId,
                CreatedAt = koiFish.CreatedAt,
                UpdatedAt = koiFish.UpdatedAt,
                Pond =new PondDto
                {
                    Id = koiFish.PondId,
                    Name = koiFish.Pond.Name,
                    Depth = koiFish.Pond.Depth,
                    Size = koiFish .Pond.Size,
                    CreatedAt = koiFish.Pond.CreatedAt,
                    UpdatedAt = koiFish.Pond .UpdatedAt,


                }
            };
        }

        public async Task<KoiFishResponse> UpdateAsync(int id, KoiFishRequest request)
        {
            var koiFish = await _context.KoiFishes.FindAsync(id);
            if (koiFish == null)
            {
                return null;  
            }

           
            koiFish.Name = !string.IsNullOrEmpty(request.Name) ? request.Name : koiFish.Name;
            koiFish.Color = !string.IsNullOrEmpty(request.Color) ? request.Color : koiFish.Color;
            koiFish.Size = request.Size > 0 ? request.Size : koiFish.Size;
            koiFish.Origin = !string.IsNullOrEmpty(request.Origin) ? request.Origin : koiFish.Origin;
            koiFish.HealthStatus = !string.IsNullOrEmpty(request.HealthStatus) ? request.HealthStatus : koiFish.HealthStatus;

            var pond = await _context.Ponds.FindAsync(id);

            if (pond != null)
            {
                koiFish.PondId = request.PondId;

            }

            await _context.SaveChangesAsync(); 

            return new KoiFishResponse
            {
                Id = koiFish.Id,
                Name = koiFish.Name,
                Color = koiFish.Color,
                Size = koiFish.Size,
                Origin = koiFish.Origin,
                HealthStatus = koiFish.HealthStatus,
                PondId = koiFish.PondId
            };
        }

    }
}
