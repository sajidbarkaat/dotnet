using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Dto;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class AccountController : ControllerBase
{
    private IUserService userService;
    public AccountController(IUserService userService)
    {
        this.userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("signup")]
    public IActionResult Signup([FromBody] UserDto userDto)
    {
        this.userService.Register(userDto);
        return Ok(new { message = "Signup successful" });
    }


    // [AllowAnonymous]
    // [HttpPost("Login")]
    // public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
    // {

    // }
}
