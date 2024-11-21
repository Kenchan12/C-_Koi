using KoiFishManager.Api.Entities;
using KoiFishManager.Models.KoiFish;

namespace KoiFishManager.API.Services
{
    public interface IKoiFishService
    {
        Task<KoiFishResponse> AddAsync(int pondId, KoiFishRequest request);

        
        Task<List<KoiFishResponse>> GetAllByUserIdAsync(Guid id);

        Task<KoiFishDetailResponse> GetByIdAsync(int id);

        // Cập nhật thông tin cá koi
        Task<KoiFishResponse> UpdateAsync(int id, KoiFishRequest request);

        // Xóa cá koi
        Task<bool> DeleteAsync(int id);
    }
}
