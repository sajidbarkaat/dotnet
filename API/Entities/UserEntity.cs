using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities;
public class UserEntity
{
    public int Id { get; set; }
    public string FName { get; set; }    
    public string LName { get; set; }
    public string Username { get; set; }                     
    public byte[] Password { get; set;}
    public byte[] Salt { get; set; }
}
