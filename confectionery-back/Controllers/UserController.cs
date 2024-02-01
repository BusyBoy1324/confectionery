using AutoMapper;
using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_back.Service.UserServices;
using confectionery_back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace confectionery_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<UserViewModel>>> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            var mapped = _mapper.Map<List<UserViewModel>>(users);
            return Ok(mapped);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetByIdAsync(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            var mapped = _mapper.Map<UserViewModel>(user);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> CreateAsync([FromBody] UserDto userDto)
        {
            User user = await _userService.InsertAsync(userDto);
            var mapped = _mapper.Map<UserViewModel>(user);
            return Ok(mapped);
        }

        [HttpPut]
        public async Task<ActionResult<UserViewModel>> UpdateAsync(
            [FromBody] User updatedUser)
        {
            await _userService.UpdateAsync(updatedUser);
            return Ok(_mapper.Map<UserViewModel>(updatedUser));
        }

        [HttpDelete]
        public async Task<ActionResult<List<UserViewModel>>> DeleteAsync([FromQuery] Guid id)
        {
            await _userService.DeleteAsync(id);
            var users = await _userService.GetAllAsync();
            var mapped = _mapper.Map<List<UserViewModel>>(users);
            return Ok(mapped);
        }
    }
}
