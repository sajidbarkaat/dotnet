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

public class SAPDNHeaderController : ControllerBase
{

    protected readonly ILogger<SAPDNHeaderController> logger;
    protected readonly TUDataContext tuDataContext;
    protected readonly ISAPDeliveryNoteHeaderService DNHeaderService;

    public SAPDNHeaderController(TUDataContext dataContext, ILogger<SAPDNHeaderController> logger, ISAPDeliveryNoteHeaderService DNHeaderService)
    {
        this.tuDataContext = dataContext;
        this.logger = logger;
        this.DNHeaderService = DNHeaderService;
    }

    //[Authorize]    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<SAP_DeliveryNoteHeader_Entity>>> Get()
    {
        var DNHeader = await this.DNHeaderService.GetAll();
        return new ActionResult<IEnumerable<SAP_DeliveryNoteHeader_Entity>>(DNHeader);
    }

}

