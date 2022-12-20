using Span.Culturio.Core.Models.Users;

namespace Span.Culturio.Users.Services
{
    public interface IUserService
    {
        Task<UsersDto> GetUsersAsync(int pageSiz, int pageIdx);
        Task<UserDto> GetUserByIdAsync(int id);
    }
}