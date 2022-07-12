using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;

public class UserRegisteredDto
{
    public int Id { get; set; }
    [Required]
    public string FName { get; set; }

    [Required]
    public string LName { get; set; }

    [Required]
    public string UserName { get; set; }
}
