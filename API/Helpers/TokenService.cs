using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API.Helpers;

public interface ITokenService {
    string CreateToken(UserEntity userEntity);    

}

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey symmetricSecurityKey;
    
    public TokenService(IConfiguration configuration) {
        this.symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));

    }
    public string CreateToken(UserEntity userEntity)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, userEntity.Username)
        };

        var credentials = new SigningCredentials(this.symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);       
    }
}
