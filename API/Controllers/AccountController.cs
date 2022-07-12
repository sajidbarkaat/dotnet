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

[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private IUserService userService;
    public AccountController(IUserService userService)
    {
        this.userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("signup")]
    public async Task<ActionResult<UserRegisteredDto>> Signup([FromBody] UserDto userDto)
    {
        UserRegisteredDto dto =  await this.userService.Register(userDto);
        return Ok(dto);
    }


    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult<UserAuthenticatedDto>> Login([FromBody] LoginCredentialsDto loginDto)
    {        
        UserAuthenticatedDto dto = await this.userService.Login(loginDto);

        if(dto == null) {
            return NotFound();
        }
        
        return Ok(dto);
    }
}
