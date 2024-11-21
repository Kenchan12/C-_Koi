using KoiFishManager.Models;
using KoiFishManager.Models.Pond;

namespace KoiFishManager.Api.Services
{
    public interface IPondService
    {
        
        Task<PondResponse> AddAsync(Guid userId, PondRequest request);

       
        Task<List<PondResponse>> GetAllByUserIdAsync(Guid userId);

        Task<PagedResult<PondResponse>> GetPagedByUserIdAsync(Guid userId, int page, int pageSize);

        
        Task<PondResponse> GetByIdAsync(int id);

        
        Task<PondResponse> UpdateAsync(int id, PondRequest pond);

       
        Task<bool> DeleteAsync(int id);
    }
}
