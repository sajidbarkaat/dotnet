using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;

public class UserDto
{
    public int Id { get; set; }
    public string FName { get; set; }    
    public string LName { get; set; }
    public string Username { get; set; }                     
    public string Password { get; set;}    
}
