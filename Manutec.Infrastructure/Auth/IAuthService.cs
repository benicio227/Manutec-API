using Manutec.Core.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Manutec.Infrastructure.Auth;
public interface IAuthService
{
    string ComputeHash(string password);

    string GenerateToken(string email, UserRole role, int workShopId);
}

public class AuthService : IAuthService
{

    private readonly IConfiguration _configuration;
    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string ComputeHash(string password)
    {
        using (var hash = SHA256.Create())
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            var hashBytes = hash.ComputeHash(passwordBytes);

            var builder = new StringBuilder();

            for (var i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }

            return builder.ToString();
        };
    }

    public string GenerateToken(string email, UserRole role, int workShopId)
    {

        var issuertrue = _configuration["JWT:Issuer"];
        var audiencetrue = _configuration["JWT:Audience"];
        var keyValuetrue = _configuration["JWT:Key"];

        Console.WriteLine($"[AuthService] JWT Key usada para gerar token: {keyValuetrue}");

        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];
        var keyValue = Environment.GetEnvironmentVariable("JWT_SECRET");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue));

 

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("WorkShopId", workShopId.ToString()),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, ((int)role).ToString()),
        };

        var token = new JwtSecurityToken(issuer, audience, claims, null, DateTime.Now.AddHours(2), credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
