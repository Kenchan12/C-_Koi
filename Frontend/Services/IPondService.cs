using KoiFishManager.Models;

namespace KoiFishManager.Web.Services
{
    public interface IPondService
    {
        Task<List<PondResponse>> GetAllPondsAsync();
        Task<PondResponse> GetPondByIdAsync(int id);
        Task CreatePondAsync(PondRequest request);
        Task UpdatePondAsync(int id, PondRequest request);
        Task DeletePondAsync(int id);

    }

}
