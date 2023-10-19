using AutoMapper;
using UsersAPI.DTOs;
using UsersAPI.Models;
using UsersAPI.Repositories.Interface;
using UsersAPI.Services.Interface;

namespace UsersAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var userByIdEntity = await _userRepository.GetById(id);
            return _mapper.Map<UserDto>(userByIdEntity);
        }

        public async Task AddUser(UserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.Create(userEntity);
            userDto.Id = userEntity.Id;
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.Update(userEntity);
        }

        public async Task RemoveUser(int id)
        {
            var userEntity = await _userRepository.GetById(id);
            await _userRepository.Delete(userEntity.Id);
        }
        
        public async Task<User> LoginUser(LoginUserDto loginDto)
        {
            var loginEntity = _mapper.Map<User>(loginDto);
            var userEntity = await _userRepository.GetByNameAndPassword(loginEntity);
            return userEntity;

        }
        public async Task UpdateStatus(UserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.UpdateStatus(userEntity);
        }

        public bool GetUserByLoginEmailCpf(UserDto userDto)
        {
            return _userRepository.GetUserByLoginEmailCpf(userDto.Login, userDto.Email, userDto.CPF);
        }


    }
}
