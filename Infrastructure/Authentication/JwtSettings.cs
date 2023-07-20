namespace Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Secret { get; init; } = "VeryStrongAndVeryLongSecretKey123456";
    public int ExpiryMinutes { get; init; } = 180;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;


}