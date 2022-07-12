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

public interface ITokenService {
    string CreateToken(UserEntity userEntity);    

}

public class TokenService : ITokenService
{
    protected readonly SymmetricSecurityKey symmetricSecurityKey;
    protected readonly  UserManager<UserEntity> userManager;

    
    public TokenService(IConfiguration configuration, UserManager<UserEntity> userManager) {
        this.symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        this.userManager = userManager;
    }
    public string CreateToken(UserEntity userEntity)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, userEntity.UserName)
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
