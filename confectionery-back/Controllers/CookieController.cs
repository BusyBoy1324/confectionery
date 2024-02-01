using AutoMapper;
using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_back.Service.CookieServices;
using confectionery_back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace confectionery_back.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CookieController : Controller
	{
		private readonly ICookieService _cookieService;
		private readonly IMapper _mapper;

		public CookieController(ICookieService cookieService, IMapper mapper)
		{
			_cookieService = cookieService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("list")]
		public async Task<ActionResult<List<CookieViewModel>>> GetAllAsync()
		{
			var cookies = await _cookieService.GetAllAsync();
			var mapped = _mapper.Map<List<CookieViewModel>>(cookies);
			return Ok(mapped);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CookieViewModel>> GetByIdAsync(Guid id)
		{
			var cookies = await _cookieService.GetByIdAsync(id);
			var mapped = _mapper.Map<CookieViewModel>(cookies);
			return Ok(mapped);
		}

		[HttpPost]
		public async Task<ActionResult<CookieViewModel>> CreateAsync([FromBody] CookieDto cookieDto)
		{
			Cookie cookie = await _cookieService.InsertAsync(cookieDto);
			var mapped = _mapper.Map<CookieViewModel>(cookie);
			return Ok(mapped);
		}

		[HttpPut]
		public async Task<ActionResult<CookieViewModel>> UpdateAsync(
			[FromBody] Cookie updatedCookie)
		{
			await _cookieService.UpdateAsync(updatedCookie);
			return Ok(_mapper.Map<CookieViewModel>(updatedCookie));
		}

		[HttpDelete]
		public async Task<ActionResult<List<CookieViewModel>>> DeleteAsync([FromQuery] Guid id)
		{
			await _cookieService.DeleteAsync(id);
			var cookies = await _cookieService.GetAllAsync();
			var mapped = _mapper.Map<List<CookieViewModel>>(cookies);
			return Ok(mapped);
		}
	}
}
