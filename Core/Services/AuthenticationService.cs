using Core.Authentication.Interfaces;
using Core.Entities;
using Core.Repositories.Interfaces;
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
            if (_userService.GetUserByUsername(username) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
