using static MudBlazor.Icons.Custom;
using System.Net.Http;
using confectionery_back.Model;
using confectionery_back.DTO;
using confectionery_front.Services.HttpServices;
using System.Net.Http.Json;

namespace confectionery_front.Services.BiscuitServices
{
    public class BiscuitService : IBiscuitService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpService _httpService;
        private readonly HttpClient _httpClient;

        public BiscuitService(IHttpClientFactory clientFactory, IHttpService httpService)
        {
            _clientFactory = clientFactory;
            _httpService = httpService;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public async Task<Biscuit> CreateAsync(BiscuitDto biscuitDto)
        {
            HttpResponseMessage response =
                await _httpClient.PostAsJsonAsync<BiscuitDto>(
                    "/api/Biscuit", biscuitDto);

            return await _httpService.CreateAsync<Biscuit>(response);
        }

        public async Task<List<Biscuit>> DeleteAsync(Guid id)
        {
            var response =
                await _httpClient.DeleteAsync($"api/Biscuit?id={id}");

            return await _httpService.DeleteAsync<Biscuit>(response);
        }

        public async Task<List<Biscuit>> GetAllAsync()
        {
            var response =
                await _httpClient.GetAsync(
                    "/api/Biscuit/list");

            return await _httpService.GetAllAsync<Biscuit>(response);
        }

        public async Task<Biscuit> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync(
                $"api/Biscuit/{id}");

            return await _httpService.GetByIdAsync<Biscuit>(response);
        }

        public async Task<Biscuit> UpdateAsync(Biscuit request)
        {
            var response = await _httpClient.PutAsJsonAsync<Biscuit>(
                "/api/Biscuit", request);

            return await _httpService.UpdateAsync<Biscuit>(response);
        }
    }
}
