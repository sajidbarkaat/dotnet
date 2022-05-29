using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Dto;
using API.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Helpers;


public interface ISAPPriceListService
{
    Task<IEnumerable<SAP_PriceListEntity>> GetAll();
}

public class SAP_PriceListService : ISAPPriceListService
{
    protected readonly ILogger<SAP_PriceListService> logger;
    protected readonly TUDataContext dataContext;
    protected readonly ITokenService tokenService;

    public SAP_PriceListService(TUDataContext dataContext, ILogger<SAP_PriceListService> logger, ITokenService tokenService)
    {
        this.dataContext = dataContext;
        this.logger = logger;
        this.tokenService = tokenService;
    }
    public async Task<IEnumerable<SAP_PriceListEntity>> GetAll()
    {
        return await this.dataContext.SAP_PriceList.ToListAsync();
    }

   
}

