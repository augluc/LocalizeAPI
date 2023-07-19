using Core.Entities;

namespace Core.Authentication.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}