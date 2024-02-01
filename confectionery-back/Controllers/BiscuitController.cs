using AutoMapper;
using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_back.Service.BiscuitServices;
using confectionery_back.Service.CookieServices;
using confectionery_back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace confectionery_back.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BiscuitController : Controller
	{
		private readonly IBiscuitService _biscuitService;
		private readonly IMapper _mapper;

		public BiscuitController(IBiscuitService biscuitService, IMapper mapper)
		{
			_biscuitService = biscuitService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("list")]
		public async Task<ActionResult<List<BiscuitViewModel>>> GetAllAsync()
		{
			var biscuits = await _biscuitService.GetAllAsync();
			var mapped = _mapper.Map<List<BiscuitViewModel>>(biscuits);
			return Ok(mapped);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BiscuitViewModel>> GetByIdAsync(Guid id)
		{
			var biscuits = await _biscuitService.GetByIdAsync(id);
			var mapped = _mapper.Map<BiscuitViewModel>(biscuits);
			return Ok(mapped);
		}

		[HttpPost]
		public async Task<ActionResult<BiscuitViewModel>> CreateAsync([FromBody] BiscuitDto biscuitDto)
		{
			Biscuit biscuit = await _biscuitService.InsertAsync(biscuitDto);
			var mapped = _mapper.Map<BiscuitViewModel>(biscuit);
			return Ok(mapped);
		}

		[HttpPut]
		public async Task<ActionResult<BiscuitViewModel>> UpdateAsync(
			[FromBody] Biscuit updatedBiscuit)
		{
			await _biscuitService.UpdateAsync(updatedBiscuit);
			return Ok(_mapper.Map<BiscuitViewModel>(updatedBiscuit));
		}

		[HttpDelete]
		public async Task<ActionResult<List<BiscuitViewModel>>> DeleteAsync([FromQuery] Guid id)
		{
			await _biscuitService.DeleteAsync(id);
			var biscuits = await _biscuitService.GetAllAsync();
			var mapped = _mapper.Map<List<BiscuitViewModel>>(biscuits);
			return Ok(mapped);
		}
	}
}
