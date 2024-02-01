using AutoMapper;
using confectionery_back.DataContext;
using confectionery_back.DTO;
using confectionery_back.Model;
using Microsoft.EntityFrameworkCore;

namespace confectionery_back.Service.OrderServices
{
	public class OrderService : IOrderService
	{
		private readonly ConfectionaryContext _context;
		private readonly IMapper _mapper;

		public OrderService(ConfectionaryContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<Order>> GetAllAsync()
		{
			return await _context.Orders.ToListAsync();
		}

		public async Task<List<Order>> GetAllCompletedAsync()
		{
			return await _context.Orders.Where(c => c.IsCompleted == true).ToListAsync();
		}

		public async Task<List<Order>> GetAllIncompletedAsync()
		{
			return await _context.Orders.Where(c => c.IsCompleted == false).ToListAsync();
		}

		public async Task<Order> GetByIdAsync(Guid id)
		{
			return await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
		}

		public async Task<Order> InsertAsync(OrderDto orderDto)
		{
			Order order = GetMappedOrder(orderDto);

			if (order is null)
			{
				throw new Exception("Can't insert order because it's null");
			}

			_context.Orders.Add(order);
			await SaveAsync();
			return order;
		}

		public async Task DeleteAsync(Guid id)
		{
			Order order = await GetByIdAsync(id);
			_context.Orders.Remove(order);
			await SaveAsync();
		}

		public async Task<Order> UpdateAsync(Order order)
		{
			_context.Orders.Update(order);
			await SaveAsync();
			return order;
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		private Order GetMappedOrder(OrderDto orderDto)
		{
			return _mapper.Map<Order>(orderDto);
		}
	}
}
