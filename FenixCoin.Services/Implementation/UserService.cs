using AutoMapper;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using FenixCoin.Dto.UserDTO;
using FenixCoin.Services.Interfaces;
using FenixCoin.Shared;
using FenixCoin.Shared.Configuration;
using FenixCoin.Shared.UserExceptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XAct;
using XSystem.Security.Cryptography;


namespace FenixCoin.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly FenixAppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IOptions<FenixAppSettings> options, IMapper mapper)
        {
            _userRepository = userRepository;
            _appSettings = options.Value;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            try
            {
                var userList = new List<UserDto>();
                var returnedList = await _userRepository.GetAll();
                var returnedListToDto = returnedList.Select(user => _mapper.Map<UserDto>(user)).ToList();
                userList = returnedListToDto;
                return userList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDto> GetUserById(int id)
        {
            try
            {
                var userDb = await _userRepository.GetById(id);
                if (userDb == null)
                {
                    throw new NotImplementedException();
                }

                var userDto = _mapper.Map<UserDto>(userDb);
                return userDto;
            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                throw new UserNotFoundException(ex.Message);
            }

        }

        public async Task<string> HashPassword(string password)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            byte[] hashBytes = mD5CryptoServiceProvider.ComputeHash(passwordBytes);

            string hashPassword = Encoding.ASCII.GetString(hashBytes);

            return hashPassword;
        }

        public async Task<string> LoginUser(LoginUserDto loginUserDto)
        {
            if (string.IsNullOrWhiteSpace(loginUserDto.Username) || string.IsNullOrWhiteSpace(loginUserDto.Password))
            {
                throw new NotImplementedException();
            }
            string hashPassword = await HashPassword(loginUserDto.Password);

            User userDb = await _userRepository.LoginUser(loginUserDto.Username, hashPassword);
            if (userDb == null)
            {
                throw new NotImplementedException();
            }
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature),
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, userDb.Username),
                        new Claim("UserId",userDb.Id.ToString())
                    })
            };

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        public async Task RegisterUser(RegisterUserDto registerUserDto)
        {
            try
            {
                await ValidateUser(registerUserDto);

                var hashPassword = await HashPassword(registerUserDto.Password);

                User user = new User
                {
                    FirstName = registerUserDto.FirstName,
                    LastName = registerUserDto.LastName,
                    Email = registerUserDto.Email,
                    Username = registerUserDto.Username,
                    Password = hashPassword,
                    Age = registerUserDto.Age,
                    Wallet = new Wallet()
                };
                user.Wallet.User = user;

                await _userRepository.Add(user);
            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                throw new UserNotFoundException(ex.Message);
            }
        }

        public async Task<UpdateUserDto> UpdateUserAsync(int id, UpdateUserDto updatedUser)
        {
            try
            {
                var user = _userRepository.GetById(id);
                if (user == null)
                {
                    new OurResponse($"User with id: {id} could not be found");
                }
                var convertUser = _mapper.Map<UpdateUserDto>(user);
                return convertUser;
            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
            catch (UserNotFoundException ex)
            { throw new UserNotFoundException(ex.Message); }
        }

        public async Task ValidateUser(RegisterUserDto registerUserDto)
        {
            if (string.IsNullOrWhiteSpace(registerUserDto.FirstName) || string.IsNullOrWhiteSpace(registerUserDto.LastName))
            {
                throw new NotImplementedException();
            }
            if (registerUserDto.FirstName.Length > 100 || registerUserDto.LastName.Length > 100)
            {
                throw new NotImplementedException();
            }
            if (registerUserDto.Email.Length > 320)
            {
                throw new NotImplementedException();
            }
            if (registerUserDto.Username.Length > 50)
            {
                throw new NotImplementedException();
            }

            var userDbEmail = await _userRepository.GetByEmail(registerUserDto.Email);
            if (userDbEmail != null)
            {
                new OurResponse("The E-mail address is already in use");
            }
            var userDbUsername = await _userRepository.GetByUsername(registerUserDto.Username);
            if (userDbUsername != null)
            {
                new OurResponse("Username is already taken");
            }

        }
    }
}
