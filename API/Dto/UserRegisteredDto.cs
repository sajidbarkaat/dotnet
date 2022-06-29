using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;

public class UserRegisteredDto
{
    public int id { get; set; }
    [Required]
    public string fName { get; set; }

    [Required]
    public string lName { get; set; }

    [Required]
    public string username { get; set; }
}
