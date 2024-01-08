using confectionery_back.DTO;
using confectionery_back.Model;

namespace confectionery_back.Service.FillingServices
{
	public interface IFillingService
	{
		public Task<List<Filling>> GetAllAsync();
		public Task DeleteAsync(Guid id);
		public Task<Filling> UpdateAsync(Filling filling);
		public Task<Filling> GetByIdAsync(Guid id);
		public Task<Filling> InsertAsync(FillingDto fillingDto);
	}
}
