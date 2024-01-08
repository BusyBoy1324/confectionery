using confectionery_back.DTO;
using confectionery_back.Model;

namespace confectionery_back.Service.BiscuitServices
{
	public interface IBiscuitService
	{
		public Task<List<Biscuit>> GetAllAsync();
		public Task DeleteAsync(Guid id);
		public Task<Biscuit> UpdateAsync(Biscuit user);
		public Task<Biscuit> GetByIdAsync(Guid id);
		public Task<Biscuit> InsertAsync(BiscuitDto userDto);
	}
}
