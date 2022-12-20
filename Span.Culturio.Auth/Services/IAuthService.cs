using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;

namespace Span.Culturio.Auth.Services
{
    public interface IAuthService
    {
        Task<UserDto> RegisterUser(CreateUserDto register);
        Task<TokenDto> LoginUser(LoginDto loginDto);
    }
}
