using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> logger;
    private readonly TUDataContext tuDataContext;
    public UserController(TUDataContext dataContext, ILogger<UserController> logger)
    {
        this.tuDataContext = dataContext;
        this.logger = logger;
    }

    [HttpGet("all")]  
    public async Task<ActionResult<IEnumerable<TUUser>>> Get() {
        return await this.tuDataContext.TUUsers.ToListAsync();
    }
}
