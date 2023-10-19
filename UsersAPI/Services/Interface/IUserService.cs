using UsersAPI.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int id);
        Task AddUser(UserDto UserDto);
        Task UpdateUser(UserDto UserDto);
        Task RemoveUser(int id);
        Task<User> LoginUser(LoginUserDto loginDTO);
        Task UpdateStatus(UserDto UserDto);
        bool GetUserByLoginEmailCpf(UserDto UserDto);

    }
}
