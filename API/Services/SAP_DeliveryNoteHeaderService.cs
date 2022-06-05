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

public interface ISAPDeliveryNoteHeaderService
{
    Task<IEnumerable<SAP_DeliveryNoteHeader_Entity>> GetAll();
}
public class SAP_DeliveryNoteHeaderService : ISAPDeliveryNoteHeaderService
{
    protected readonly ILogger<SAP_DeliveryNoteHeaderService> logger;
    protected readonly TUDataContext dataContext;
    protected readonly ITokenService tokenService;

    public SAP_DeliveryNoteHeaderService(TUDataContext dataContext, ILogger<SAP_DeliveryNoteHeaderService> logger, ITokenService tokenService)
    {
        this.dataContext = dataContext;
        this.logger = logger;
        this.tokenService = tokenService;
    }
    public async Task<IEnumerable<SAP_DeliveryNoteHeader_Entity>> GetAll()
    {
        return await this.dataContext.SAP_DeliveryNote_Header.ToListAsync();
    }

}

