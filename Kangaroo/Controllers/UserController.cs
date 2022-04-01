using AutoMapper;
using KangarooTest.Models;
using KangarooTest.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KangarooTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login User")]
        public async Task<IActionResult> Authenticate(AuthenticateUserRequest authenticateUserRequest)
        {
            var result = await _userService.AuthenticateAsync(authenticateUserRequest);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("Register User")]
        public async Task<IActionResult> CreateUserAsync(CreateUserRequest createUserRequest)
        {
            var result = await _userService.CreateAsync(createUserRequest);

            _logger.LogInformation("User was created");
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetAllAsync();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, UpdateUserRequest updateUserRequest)
        {
            var result = await _userService.UpdateAsync(updateUserRequest);
           
            _logger.LogInformation($"Updated user with Id: {id}");

            return Ok(result);
        }
    }
}
