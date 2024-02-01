using confectionery_back.DTO;
using confectionery_back.Model;

namespace confectionery_front.Services.FillingServices
{
	public interface IFillingService
	{
        public Task<Filling> CreateAsync(FillingDto fillingDto);
        public Task<List<Filling>> DeleteAsync(Guid id);
        public Task<List<Filling>> GetAllAsync();
        public Task<Filling> GetByIdAsync(Guid id);
        public Task<Filling> UpdateAsync(Filling request);
    }
}
