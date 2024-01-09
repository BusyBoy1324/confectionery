using AutoMapper;
using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_back.Service.OrderServices;
using confectionery_back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace confectionery_back.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrderController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("list")]
		public async Task<ActionResult<List<OrderViewModel>>> GetAllAsync()
		{
			var orders = await _orderService.GetAllAsync();
			var mapped = _mapper.Map<List<OrderViewModel>>(orders);
			return Ok(mapped);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OrderViewModel>> GetByIdAsync(Guid id)
		{
			var orders = await _orderService.GetByIdAsync(id);
			var mapped = _mapper.Map<OrderViewModel>(orders);
			return Ok(mapped);
		}

		[HttpPost]
		public async Task<ActionResult<OrderViewModel>> CreateAsync([FromBody] OrderDto orderDto)
		{
			Order order = await _orderService.InsertAsync(orderDto);
			var mapped = _mapper.Map<OrderViewModel>(order);
			return Ok(mapped);
		}

		[HttpPut]
		public async Task<ActionResult<OrderViewModel>> UpdateAsync(
			[FromBody] Order updatedOrder)
		{
			await _orderService.UpdateAsync(updatedOrder);
			return Ok(_mapper.Map<OrderViewModel>(updatedOrder));
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<OrderViewModel>>> DeleteAsync(Guid id)
		{
			await _orderService.DeleteAsync(id);
			var orders = await _orderService.GetAllAsync();
			var mapped = _mapper.Map<List<OrderViewModel>>(orders);
			return Ok(mapped);
		}
	}
}
