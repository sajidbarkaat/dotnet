using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;

public class UserAuthenticatedDto
{
    public UserAuthenticatedDto(string username, string token)
    {        
        this.UserName = username;
        this.Token = token;
    }   

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Token { get; set; }
}

