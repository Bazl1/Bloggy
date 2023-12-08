using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bloggy.Application.Services.Authorization;
using Bloggy.Domain.Entites;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bloggy.Infrastructure.Services.Authorization;

public class JwtTokenGenerator(
    IOptions<JwtSettings> _jwtSettings
) : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Value.Secret)
            ),
            SecurityAlgorithms.HmacSha256
        );

        Claim[] claims = [
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        ];

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Value.Issuer,
            audience: _jwtSettings.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.Value.ExpiryMinutes),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}
