using DataPush.Domain.Commands;
using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataPush.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
            => _userRepository = userRepository;

        [HttpPost("v1/users/authenticate")]
        public IActionResult VerifyLogin([FromBody] VerifyUserLoginCommand command)
            => Ok(_userRepository.Authenticate(command.Email, command.Password));

        [HttpGet("v1/users")]
        public async Task<IActionResult> GetUsers()
            => Ok(await _userRepository.Get());

        [HttpGet("v1/users/{userId:guid}")]
        public async Task<IActionResult> GetUser(Guid userId)
            => Ok(await _userRepository.Get(userId));

        [HttpPost("v1/users")]
        public IActionResult PostUser([FromBody] CreateUserCommand command)
        {
            var user = new User(command.Name, command.Document, command.Password, command.Email);
            _userRepository.Save(user);
            return Ok(user.Id);
        }
    }
}