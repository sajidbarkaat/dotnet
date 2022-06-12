using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;

[Route("api/[controller]")]
public class UserController: ControllerBase
{
    protected readonly ILogger<UserController> logger;
    protected readonly TUDataContext tuDataContext;

    protected readonly IUserService userService;
    public UserController(TUDataContext dataContext, ILogger<UserController> logger, IUserService userService)
    {
        this.tuDataContext = dataContext;
        this.logger = logger;
        this.userService = userService;
    }     

    [Authorize]    
    [HttpGet("all")]  
    public async Task<ActionResult<IEnumerable<UserEntity>>> Get() {
        var userList =  await this.userService.GetAll();        
        return new ActionResult<IEnumerable<UserEntity>>(userList);
    }

    ////[Authorize]
    [HttpPost("save")]
    public async Task<ActionResult<IEnumerable<UserEntity>>> SaveUser([FromBody] UserEntity cmd)
    {
        var userList = await this.userService.GetAll();
        return new ActionResult<IEnumerable<UserEntity>>(userList);
    }
}
