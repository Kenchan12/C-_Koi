using KoiFishManager.Models;
using System.Net.Http.Json;

namespace KoiFishManager.Web.Services
{
    public class PondAPIService : IPondService
    {
        private readonly HttpClient _httpClient;

        public PondAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PondResponse>> GetAllPondsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<PondResponse>>("api/pond/all");
        }

        public async Task<PondResponse> GetPondByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<PondResponse>($"api/pond/{id}");
        }

        public async Task CreatePondAsync(PondRequest request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/pond", request);
            _ = response.EnsureSuccessStatusCode();
        }

        public async Task UpdatePondAsync(int id, PondRequest request)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/pond/{id}", request);
            _ = response.EnsureSuccessStatusCode();
        }

        public async Task DeletePondAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/pond/{id}");
            _ = response.EnsureSuccessStatusCode();
        }
    }
}
