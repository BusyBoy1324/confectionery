using AutoMapper;
using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_back.Service.FillingServices;
using confectionery_back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace confectionery_back.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FillingController : Controller
	{
		private readonly IFillingService _fillingService;
		private readonly IMapper _mapper;

		public FillingController(IFillingService fillingService, IMapper mapper)
		{
			_fillingService = fillingService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("list")]
		public async Task<ActionResult<List<FillingViewModel>>> GetAllAsync()
		{
			var fillings = await _fillingService.GetAllAsync();
			var mapped = _mapper.Map<List<FillingViewModel>>(fillings);
			return Ok(mapped);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<FillingViewModel>> GetByIdAsync(Guid id)
		{
			var filling = await _fillingService.GetByIdAsync(id);
			var mapped = _mapper.Map<FillingViewModel>(filling);
			return Ok(mapped);
		}

		[HttpPost]
		public async Task<ActionResult<FillingViewModel>> CreateAsync([FromBody] FillingDto fillingDto)
		{
			Filling filling = await _fillingService.InsertAsync(fillingDto);
			var mapped = _mapper.Map<FillingViewModel>(filling);
			return Ok(mapped);
		}

		[HttpPut]
		public async Task<ActionResult<FillingViewModel>> UpdateAsync(
			[FromBody] Filling updatedFilling)
		{
			await _fillingService.UpdateAsync(updatedFilling);
			return Ok(_mapper.Map<FillingViewModel>(updatedFilling));
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<FillingViewModel>>> DeleteAsync(Guid id)
		{
			await _fillingService.DeleteAsync(id);
			var fillings = await _fillingService.GetAllAsync();
			var mapped = _mapper.Map<List<FillingViewModel>>(fillings);
			return Ok(mapped);
		}
	}
}
