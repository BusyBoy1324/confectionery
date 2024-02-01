using confectionery_back.DTO;
using confectionery_back.Model;

namespace confectionery_front.Services.UserServices
{
	public interface IUserService
	{
        public Task<User> CreateAsync(UserDto userDto);
        public Task<List<User>> DeleteAsync(Guid id);
        public Task<List<User>> GetAllAsync();
        public Task<User> GetByIdAsync(Guid id);
        public Task<User> UpdateAsync(User request);
    }
}
