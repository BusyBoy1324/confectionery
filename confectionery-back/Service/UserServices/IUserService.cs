using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_back.ViewModels;

namespace confectionery_back.Service.UserServices
{
    public interface IUserService
    {
        public Task<List<User>> GetAllAsync();
        public Task DeleteAsync(Guid id);
        public Task<User> UpdateAsync(User user);
        public Task<User> GetByIdAsync(Guid id);
        public Task<User> InsertAsync(UserDto userDto);
    }
}
