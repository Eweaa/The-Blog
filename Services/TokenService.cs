using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Services;

public class TokenService
{
    private readonly IConfiguration Configuration;

    public TokenService(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    public async Task<string> CreateToken(AppUser user)
    {
        var userClaims = new List<Claim>()
        {
            new Claim("Name", user.UserName),
            new Claim("Email", user.Email),
            new Claim("UserId", user.Id),
        };
        
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]));
        
        var token = new JwtSecurityToken
        (
            audience: Configuration["JWT:ValidAudience"], 
            issuer: Configuration["JWT:ValidIssuer"],
            expires: DateTime.Now.AddDays(7),
            claims: userClaims,
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}