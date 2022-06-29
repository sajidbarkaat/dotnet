using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Dto;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;

[Route("api/[controller]")]
public class SAPDNRowController : ControllerBase
{
    protected readonly ILogger<SAPDNRowController> logger;
    protected readonly TUDataContext tuDataContext;
    protected readonly ISAPDeliveryNoteRowService DNRowService;

    public SAPDNRowController(TUDataContext dataContext, ILogger<SAPDNRowController> logger, ISAPDeliveryNoteRowService DNRowService)
    {
        this.tuDataContext = dataContext;
        this.logger = logger;
        this.DNRowService = DNRowService;
    }

    //[Authorize]    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<SAPDeliveryNoteRowEntity>>> Get()
    {
        var DNRow = await this.DNRowService.GetAll();
        return new ActionResult<IEnumerable<SAPDeliveryNoteRowEntity>>(DNRow);
    }

    //[Authorize]    
    [HttpPost("Save")]
    public IActionResult Save([FromBody] SAPDeliveryNoteRowDto DNRowDto)
    {
        this.DNRowService.Save(DNRowDto);
        return Ok(new { message = "Save successful" });
    }



}

