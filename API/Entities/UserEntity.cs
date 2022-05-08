using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Entities;

[Index(nameof(Username), IsUnique=true)]
public class UserEntity
{
    public int Id { get; set; }

    [Required]
    public string FName { get; set; }    
    
    [Required]
    public string LName { get; set; }

    [Required]
    public string Username { get; set; }                     

    [Required]
    public byte[] Password { get; set;}
    
    [Required]
    public byte[] Salt { get; set; }
}
