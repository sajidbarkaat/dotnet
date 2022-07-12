using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Entities;

[Table("Users")]
public class UserEntity: IdentityUser<int>
{
    [Required]
    public string FName { get; set; }    
    
    [Required]
    public string LName { get; set; }

    public ICollection<UserRoleEntity> UserRoles { get; set; }
    
}
