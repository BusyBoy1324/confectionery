using confectionery_back.DTO;
using confectionery_back.Model;

namespace confectionery_front.Services.OrderServices
{
	public interface IOrderService
	{
        public Task<Order> CreateAsync(OrderDto orderDto);
        public Task<List<Order>> DeleteAsync(Guid id);
        public Task<List<Order>> GetAllAsync();
        public Task<List<Order>> GetAllCompletedAsync();
        public Task<List<Order>> GetAllIncompletedAsync();
        public Task<Order> GetByIdAsync(Guid id);
        public Task<Order> UpdateAsync(Order request);
    }
}
