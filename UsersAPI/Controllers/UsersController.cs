using Microsoft.AspNetCore.Mvc;
using UsersAPI.Attributes;
using UsersAPI.DTOs;
using UsersAPI.Services.Interface;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        List<string> statusList = new List<string> { "BLOQUEADO", "ATIVO", "INATIVADO" };
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [ApiKey]
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var usersDto = await _userService.GetUsers();

            if (usersDto == null) { return NotFound(); }

            return Ok(usersDto);
        }

        [HttpGet("GetByIdUser/{id:int}", Name = "Get")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var userDto = await _userService.GetUserById(id);
            if (userDto == null) { return NotFound(); }
            return Ok(userDto);
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult> Post([FromBody] UserDto userDto)
        {
            if (userDto == null) { return BadRequest("Invalid User"); }
            var userEntity = _userService.GetUserByLoginEmailCpf(userDto);
            if (!userEntity)
            {
                userDto.InclusionDate = DateTime.Now;
                await _userService.AddUser(userDto);
                return Ok(userDto);
            }
            else
            {
                return NotFound("User already exists.");
            }
        }
        [HttpDelete("DeleteById/{id:int}")]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            var userDto = await _userService.GetUserById(id);
            if (userDto == null) { return BadRequest("No record to delete"); }

            await _userService.RemoveUser(id);

            return Ok("Deleted");
        }

        [HttpPut("UpdateUser/{id:int}", Name = "Put")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto userDto)
        {
            if (userDto == null) { return NotFound(); }
            var userEntity = _userService.GetUserByLoginEmailCpf(userDto);
            if (!userEntity)
            {
                userDto.Id = id;
                userDto.ChangeDate = DateTime.Now;
                await _userService.UpdateUser(userDto);
                return Ok(userDto);
            }
            else
            {
                return NotFound("User already exists.");
            }

        }

        [HttpPost("LoginPage")]
        public async Task<ActionResult> Post([FromBody] LoginUserDto loginUserDto)
        {
            if (loginUserDto == null) { return NotFound(); }
            var loginUser = _userService.LoginUser(loginUserDto).Result;
            if (loginUser == null) { return NotFound("Usuário ou senha incorretos e/ou usuário inátivo."); }
            return Ok($"Login efetuado com sucesso: {loginUser.Login}");
        }

        [HttpPut("ChangeStatusById/{id:int}", Name = "ChangeStatus")]
        public async Task<ActionResult> ChangeStatus(int id, [FromBody] string status)
        {
            if (id < 1 || string.IsNullOrEmpty(status) || !statusList.Contains(status))
            {
                return BadRequest("Id ou Status estão incorretos e/ou inválidos.");
            }

            var UserDto = await _userService.GetUserById(id);
            if (UserDto == null) { return NotFound(); }

            UserDto.Status = status.ToUpper();
            UserDto.ChangeDate = DateTime.Now;
            await _userService.UpdateStatus(UserDto);
            return Ok("Changed");
        }
    }
}
