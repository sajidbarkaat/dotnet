using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;

public class LoginCredentialsDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}