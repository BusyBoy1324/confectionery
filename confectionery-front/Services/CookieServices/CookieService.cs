using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_front.Services.HttpServices;

namespace confectionery_front.Services.CookieServices
{

    public class CookieService : ICookieService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpService _httpService;
        private readonly HttpClient _httpClient;

        public CookieService(IHttpClientFactory clientFactory, IHttpService httpService)
        {
            _clientFactory = clientFactory;
            _httpService = httpService;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public async Task<Cookie> CreateAsync(CookieDto cookieDto)
        {
            HttpResponseMessage response =
                await _httpClient.PostAsJsonAsync<CookieDto>(
                    "/api/Cookie", cookieDto);

            return await _httpService.CreateAsync<Cookie>(response);
        }

        public async Task<List<Cookie>> DeleteAsync(Guid id)
        {
            var response =
                await _httpClient.DeleteAsync($"api/Cookie?id={id}");

            return await _httpService.DeleteAsync<Cookie>(response);
        }

        public async Task<List<Cookie>> GetAllAsync()
        {
            var response =
                await _httpClient.GetAsync(
                    "/api/Cookie/list");

            return await _httpService.GetAllAsync<Cookie>(response);
        }

        public async Task<Cookie> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync(
                $"api/Cookie/{id}");

            return await _httpService.GetByIdAsync<Cookie>(response);
        }

        public async Task<Cookie> UpdateAsync(Cookie request)
        {
            var response = await _httpClient.PutAsJsonAsync<Cookie>(
                "/api/Cookie", request);

            return await _httpService.UpdateAsync<Cookie>(response);
        }
    }
}
