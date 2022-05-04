using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[Route("api/[controller]")]
public abstract class BaseAPIController<T> : ControllerBase
{
    // protected readonly ILogger<T> logger;
    // protected readonly TUDataContext tuDataContext;
    // public BaseAPIController(TUDataContext dataContext, ILogger<T> logger)
    // {
    //     this.tuDataContext = dataContext;
    //     this.logger = logger;
    // }     

    public BaseAPIController() {}
}
