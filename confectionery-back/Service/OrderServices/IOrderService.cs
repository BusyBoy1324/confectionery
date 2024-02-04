using confectionery_back.DTO;
using confectionery_back.Model;

namespace confectionery_back.Service.OrderServices
{
	public interface IOrderService
	{
		public Task<List<Order>> GetAllAsync();
		public Task<List<Order>> GetAllByDatesAsync(DateTime start, DateTime end);

        public Task<List<Order>> GetAllCompletedAsync();
		public Task<List<Order>> GetAllIncompletedAsync();
        public Task DeleteAsync(Guid id);
		public Task<Order> UpdateAsync(Order order);
		public Task<Order> GetByIdAsync(Guid id);
		public Task<Order> InsertAsync(OrderDto orderDto);
	}
}
