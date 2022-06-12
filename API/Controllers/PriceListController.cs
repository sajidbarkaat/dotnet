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
public class PriceListController : ControllerBase
{

 protected readonly ILogger<PriceListController> logger;
 protected readonly TUDataContext tuDataContext;
 protected readonly ISAPPriceListService priceListService;

    public PriceListController(TUDataContext dataContext, ILogger<PriceListController> logger, ISAPPriceListService priceListService)
    {
        this.tuDataContext = dataContext;
        this.logger = logger;
        this.priceListService = priceListService;
    }

    //[Authorize]    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<SAP_PriceListEntity>>> Get()
    {
        var priceList = await this.priceListService.GetAll();
        return new ActionResult<IEnumerable<SAP_PriceListEntity>>(priceList);
    }



}
