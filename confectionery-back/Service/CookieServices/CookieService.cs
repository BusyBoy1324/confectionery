using AutoMapper;
using confectionery_back.DataContext;
using confectionery_back.DTO;
using confectionery_back.Model;
using Microsoft.EntityFrameworkCore;

namespace confectionery_back.Service.CookieServices
{
	public class CookieService : ICookieService
	{
		private readonly ConfectionaryContext _context;
		private readonly IMapper _mapper;

		public CookieService(ConfectionaryContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<Cookie>> GetAllAsync()
		{
			return await _context.Cookies.ToListAsync();
		}

		public async Task<Cookie> GetByIdAsync(Guid id)
		{
			return await _context.Cookies.FirstOrDefaultAsync(cookie => cookie.Id == id);
		}

		public async Task<Cookie> InsertAsync(CookieDto cookieDto)
		{
			Cookie cookie = GetMappedCookie(cookieDto);

			if (cookie is null)
			{
				throw new Exception("Can't insert cookie because it's null");
			}

			_context.Cookies.Add(cookie);
			await SaveAsync();
			return cookie;
		}

		public async Task DeleteAsync(Guid id)
		{
			Cookie cookie = await GetByIdAsync(id);
			_context.Cookies.Remove(cookie);
			await SaveAsync();
		}

		public async Task<Cookie> UpdateAsync(Cookie cookie)
		{
			_context.Cookies.Update(cookie);
			await SaveAsync();
			return cookie;
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		private Cookie GetMappedCookie(CookieDto cookieDto)
		{
			return _mapper.Map<Cookie>(cookieDto);
		}
	}
}
