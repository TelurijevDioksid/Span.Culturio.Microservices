using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Auth.Services;
using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;

namespace Span.Culturio.Auth.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Tags("Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidator<CreateUserDto> _validator;

        public AuthController(IAuthService authService, IValidator<CreateUserDto> validator)
        {
            _authService = authService;
            _validator = validator;
        }

        /// <summary>
        /// Register new user
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser(CreateUserDto registerUserDto)
        {
            ValidationResult result = _validator.Validate(registerUserDto);
            if (!result.IsValid)
                return BadRequest("ValidationError");

            var user = await _authService.RegisterUser(registerUserDto);
            if (user is null) return BadRequest();

            return Ok("Successful response");
        }

        /// <summary>
        /// Login
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginUserDto)
        {
            var token = await _authService.LoginUser(loginUserDto);
            if (token is null)
                return BadRequest("Bad username or password");

            return Ok(token);
        }
    }
}
