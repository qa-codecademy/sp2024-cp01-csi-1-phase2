using FenixCoin.Dto.UserDTO;
using FenixCoin.Services.Interfaces;
using FenixCoin.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using XAct;

namespace FenixCoin.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            await _userService.RegisterUser(registerUserDto);
            return StatusCode(StatusCodes.Status201Created, "User Created!");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto loginUserDto)
        {
            string token = await _userService.LoginUser(loginUserDto);
            return Ok(token);

        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userDb = await _userService.GetAllUsersAsync();
            return Ok(userDb);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) { new OurResponse("User could not be found"); }
            var updateUser = await _userService.UpdateUserAsync(id, updateUserDto);
            return Ok(updateUser);
        }
    }
}
