using confectionery_back.DTO;
using confectionery_back.Model;

namespace confectionery_back.Service.OrderServices
{
	public interface IOrderService
	{
		public Task<List<Order>> GetAllAsync();
		public Task DeleteAsync(Guid id);
		public Task<Order> UpdateAsync(Order order);
		public Task<Order> GetByIdAsync(Guid id);
		public Task<Order> InsertAsync(OrderDto orderDto);
	}
}
