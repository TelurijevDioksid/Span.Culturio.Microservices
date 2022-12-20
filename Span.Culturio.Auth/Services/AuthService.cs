using AutoMapper;
using Span.Culturio.Auth.Data.Entities;
using Span.Culturio.Auth.Helpers;
using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;
using Span.Culturio.Users.Data;

namespace Span.Culturio.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext dataContext, IMapper mapper, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            this._configuration = configuration;
        }

        public async Task<UserDto> RegisterUser(CreateUserDto register)
        {
            var user = _mapper.Map<User>(register);

            AuthHelpers.CreatePasswordHash(register.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            _dataContext.Add(user);
            await _dataContext.SaveChangesAsync();
            var usdt = _mapper.Map<UserDto>(user);
            return usdt;
        }

        public async Task<TokenDto> LoginUser(LoginDto loginDto)
        {
            var user = _dataContext.Users.SingleOrDefault(o => o.UserName == loginDto.Username);

            if (user is null)
                return null;

            if (!AuthHelpers.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt)) return null;

            var token = AuthHelpers.CreateToken(loginDto, _configuration.GetSection("JWT_KEY").Value);

            return new TokenDto { Token = token };
        }
    }
}
