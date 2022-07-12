using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;

public class LoginCredentialsDto
{     
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
