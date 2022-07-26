using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Helpers;

public interface ITokenService
{
    string CreateToken(string username, IList<string> userRoles);

}

public class TokenService : ITokenService
{
    protected readonly SymmetricSecurityKey symmetricSecurityKey;
    protected readonly IConfiguration configuration;

    public TokenService(IConfiguration configuration)
    {
        this.configuration = configuration;
        this.symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));    
    }

    public string CreateToken(string userName, IList<string> userRoles)
    {
        var claims = new List<Claim>
        {            
            new Claim(JwtRegisteredClaimNames.NameId, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var userRole in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, userRole));            
        }

        var credentials = new SigningCredentials(this.symmetricSecurityKey, SecurityAlgorithms.HmacSha256);  

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = this.configuration["Jwt:Issuer"],
            Audience = this.configuration["Jwt:Audience"],
            Expires = DateTime.Now.AddHours(3),
            Subject = new ClaimsIdentity(claims),            
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
