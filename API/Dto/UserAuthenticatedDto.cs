using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;

public class UserAuthenticatedDto
{
    public UserAuthenticatedDto(int id, string username, string token)
    {
        this.id = id;
        this.username = username;
        this.token = token;
    }

    [Required]
    public int id;

    [Required]
    public string username { get; set; }

    [Required]
    public string token { get; set; }
}

