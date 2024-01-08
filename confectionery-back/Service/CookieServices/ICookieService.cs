using confectionery_back.DTO;
using confectionery_back.Model;

namespace confectionery_back.Service.CookieServices
{
	public interface ICookieService
	{
		public Task<List<Cookie>> GetAllAsync();
		public Task DeleteAsync(Guid id);
		public Task<Cookie> UpdateAsync(Cookie cookie);
		public Task<Cookie> GetByIdAsync(Guid id);
		public Task<Cookie> InsertAsync(CookieDto coockieDto);
	}
}
