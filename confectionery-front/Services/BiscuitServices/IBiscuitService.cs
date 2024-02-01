using confectionery_back.DTO;
using confectionery_back.Model;
using System.Net.Http;

namespace confectionery_front.Services.BiscuitServices
{
    public interface IBiscuitService
    {
        public Task<Biscuit> CreateAsync(BiscuitDto biscuitDto);
        public Task<List<Biscuit>> DeleteAsync(Guid id);
        public Task<List<Biscuit>> GetAllAsync();
        public Task<Biscuit> GetByIdAsync(Guid id);
        public Task<Biscuit> UpdateAsync(Biscuit request);
        
    }
}
