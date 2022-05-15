﻿using DataPush.Domain.Commands;
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

        [HttpGet("v1/users/verify-login")]
        public async Task<IActionResult> VerifyLogin([FromBody] VerifyUserLoginCommand command)
            => Ok(await _userRepository.VerifyLogin(command.Email, command.Password));

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
            return Ok($"Usuário criado ({user.Id})");
        }
    }
}