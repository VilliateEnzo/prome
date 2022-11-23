using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Prone.Bll.Interfaces;
using Prone.Dal.Models;

namespace Prone.Bll.Services;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;
        
    public TokenService(IConfiguration config)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
    }

    public string createToken(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
        };

        SigningCredentials creds = new(_key, SecurityAlgorithms.HmacSha512Signature);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}