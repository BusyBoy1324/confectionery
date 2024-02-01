using confectionery_back.DTO;
using confectionery_back.Model;

namespace confectionery_front.Services.CookieServices
{
	public interface ICookieService
	{
        public Task<Cookie> CreateAsync(CookieDto cookieDto);
        public Task<List<Cookie>> DeleteAsync(Guid id);
        public Task<List<Cookie>> GetAllAsync();
        public Task<Cookie> GetByIdAsync(Guid id);
        public Task<Cookie> UpdateAsync(Cookie request);
    }
}
