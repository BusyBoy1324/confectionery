using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_front.Services.HttpServices;

namespace confectionery_front.Services.OrderServices
{
	public class OrderService : IOrderService
	{
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpService _httpService;
        private readonly HttpClient _httpClient;

        public OrderService(IHttpClientFactory clientFactory, IHttpService httpService)
        {
            _clientFactory = clientFactory;
            _httpService = httpService;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public async Task<Order> CreateAsync(OrderDto orderDto)
        {
            HttpResponseMessage response =
                await _httpClient.PostAsJsonAsync<OrderDto>(
                    "/api/Order", orderDto);

            return await _httpService.CreateAsync<Order>(response);
        }

        public async Task<List<Order>> DeleteAsync(Guid id)
        {
            var response =
                await _httpClient.DeleteAsync($"api/Order?id={id}");

            return await _httpService.DeleteAsync<Order>(response);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var response =
                await _httpClient.GetAsync(
                    "/api/Order/list");

            return await _httpService.GetAllAsync<Order>(response);
        }

        public async Task<List<Order>> GetAllByDatesAsync(DateTime start, DateTime end)
        {
            var response = await _httpClient.GetAsync(
                $"api/Order/filter?start={start}&&end={end}");

            return await _httpService.GetAllAsync<Order>(response);
        }

        public async Task<List<Order>> GetAllCompletedAsync()
        {
            var response =
                await _httpClient.GetAsync(
                    "/api/Order/completed");

            return await _httpService.GetAllAsync<Order>(response);
        }

        public async Task<List<Order>> GetAllIncompletedAsync()
        {
            var response =
                await _httpClient.GetAsync(
                    "/api/Order/incompleted");

            return await _httpService.GetAllAsync<Order>(response);
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync(
                $"api/Order/{id}");

            return await _httpService.GetByIdAsync<Order>(response);
        }

        public async Task<Order> UpdateAsync(Order request)
        {
            var response = await _httpClient.PutAsJsonAsync<Order>(
                "/api/Order", request);

            return await _httpService.UpdateAsync<Order>(response);
        }
    }
}
