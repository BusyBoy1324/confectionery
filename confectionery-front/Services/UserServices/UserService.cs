using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_front.Services.HttpServices;

namespace confectionery_front.Services.UserServices
{
	public class UserService : IUserService
	{
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpService _httpService;
        private readonly HttpClient _httpClient;

        public UserService(IHttpClientFactory clientFactory, IHttpService httpService)
        {
            _clientFactory = clientFactory;
            _httpService = httpService;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public async Task<User> CreateAsync(UserDto userDto)
        {
            HttpResponseMessage response =
                await _httpClient.PostAsJsonAsync<UserDto>(
                    "/api/User", userDto);

            return await _httpService.CreateAsync<User>(response);
        }

        public async Task<List<User>> DeleteAsync(Guid id)
        {
            var response =
                await _httpClient.DeleteAsync($"api/User?id={id}");

            return await _httpService.DeleteAsync<User>(response);
        }

        public async Task<List<User>> GetAllAsync()
        {
            var response =
                await _httpClient.GetAsync(
                    "/api/User/list");

            return await _httpService.GetAllAsync<User>(response);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync(
                $"api/User/{id}");

            return await _httpService.GetByIdAsync<User>(response);
        }

        public async Task<User> UpdateAsync(User request)
        {
            var response = await _httpClient.PutAsJsonAsync<User>(
                "/api/User", request);

            return await _httpService.UpdateAsync<User>(response);
        }
    }
}
