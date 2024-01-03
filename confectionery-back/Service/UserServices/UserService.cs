using AutoMapper;
using confectionery_back.DataContext;
using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_back.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace confectionery_back.Service.UserServices
{
    public class UserService : IUserService
    {
        private readonly ConfectionaryContext _context;
        private readonly IMapper _mapper;

        public UserService(ConfectionaryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> InsertAsync(UserDto userDto)
        {
            User user = GetMappedUser(userDto);

            if (user is null)
            {
                throw new Exception("Can't insert user because it's null");
            }

            _context.Users.Add(user);
            await SaveAsync();
            return user;
        }

        public async Task DeleteAsync(Guid id)
        {
            User user = await GetByIdAsync(id);
            _context.Users.Remove(user);
            await SaveAsync();
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await SaveAsync();
            return user;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private User GetMappedUser(UserDto userDto)
        {
            return _mapper.Map<User>(userDto);
        }
    }
}
