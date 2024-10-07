using FenixCoin.Domain.Models;
using FenixCoin.Dto.UserDTO;

namespace FenixCoin.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(RegisterUserDto registerUserDto);
        Task<string> LoginUser(LoginUserDto loginUserDto);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UpdateUserDto> UpdateUserAsync(int id, UpdateUserDto updatedUser);
        Task ValidateUser(RegisterUserDto registerUserDto);
        Task<string> HashPassword(string password);
        Task<UserDto> GetUserById(int id);
    }
}
