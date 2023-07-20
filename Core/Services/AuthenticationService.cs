using Core.Authentication.Interfaces;
using Core.Exceptions;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserService _userService;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserService userService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userService = userService;
        }

        public string Login(string username, string password)
        {
            var user = _userService.GetByUsername(username);

            if (user is null || user.Password != password) throw new InvalidUserCredentialsException();

            return _jwtTokenGenerator.GenerateToken(user);
        }
    }
}
