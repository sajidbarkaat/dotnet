using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;

public class UserRegisteredDto
{
    public string Id { get; set; }    
    
    public string UserName { get; set; }
}
