using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_front.Services.HttpServices;

namespace confectionery_front.Services.FillingServices
{
	public class FillingService : IFillingService
	{
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpService _httpService;
        private readonly HttpClient _httpClient;

        public FillingService(IHttpClientFactory clientFactory, IHttpService httpService)
        {
            _clientFactory = clientFactory;
            _httpService = httpService;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public async Task<Filling> CreateAsync(FillingDto fillingDto)
        {
            HttpResponseMessage response =
                await _httpClient.PostAsJsonAsync<FillingDto>(
                    "/api/Filling", fillingDto);

            return await _httpService.CreateAsync<Filling>(response);
        }

        public async Task<List<Filling>> DeleteAsync(Guid id)
        {
            var response =
                await _httpClient.DeleteAsync($"api/Filling?id={id}");

            return await _httpService.DeleteAsync<Filling>(response);
        }

        public async Task<List<Filling>> GetAllAsync()
        {
            var response =
                await _httpClient.GetAsync(
                    "/api/Filling/list");

            return await _httpService.GetAllAsync<Filling>(response);
        }

        public async Task<Filling> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync(
                $"api/Filling/{id}");

            return await _httpService.GetByIdAsync<Filling>(response);
        }

        public async Task<Filling> UpdateAsync(Filling request)
        {
            var response = await _httpClient.PutAsJsonAsync<Filling>(
                "/api/Filling", request);

            return await _httpService.UpdateAsync<Filling>(response);
        }
    }
}
