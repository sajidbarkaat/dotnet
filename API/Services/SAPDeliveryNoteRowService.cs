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

public interface ISAPDeliveryNoteRowService
{
    void Save(SAPDeliveryNoteRowDto DNRowDto);
    Task<IEnumerable<SAPDeliveryNoteRowEntity>> GetAll();
}
public class SAPDeliveryNoteRowService : ISAPDeliveryNoteRowService
{
    protected readonly ILogger<SAP_DeliveryNoteHeaderService> logger;
    protected readonly TUDataContext dataContext;
    protected readonly ITokenService tokenService;

    public SAPDeliveryNoteRowService(TUDataContext dataContext, ILogger<SAP_DeliveryNoteHeaderService> logger, ITokenService tokenService)
    {
        this.dataContext = dataContext;
        this.logger = logger;
        this.tokenService = tokenService;
    }
    public async Task<IEnumerable<SAPDeliveryNoteRowEntity>> GetAll()
    {
        return await this.dataContext.SAPDeliveryNoteRow.ToListAsync();
    }

    public void Save(SAPDeliveryNoteRowDto DNRowDto)
    {

        SAPDeliveryNoteRowEntity DNRowEntity = new SAPDeliveryNoteRowEntity
        {
            DNRId = DNRowDto.DNRId,
            DNNo = DNRowDto.DNNo,
            ItemCode = DNRowDto.ItemCode,
            ItemName = DNRowDto.ItemName,
            PriceBefDiscount = DNRowDto.PriceBefDiscount,
            DiscountPercent = DNRowDto.DiscountPercent,
            UnitPrice = DNRowDto.UnitPrice,
            VATCode = DNRowDto.VATCode,
            WareHouseCode = DNRowDto.WareHouseCode,
            UOMName = DNRowDto.UOMName,
            UOMGroupCode = DNRowDto.UOMGroupCode,
            UOMCode = DNRowDto.UOMCode,
            TrcukName = DNRowDto.TrcukName,
            TruckEnglishName = DNRowDto.TruckEnglishName,
            TruckLicensePlate = DNRowDto.TruckLicensePlate,
            TrcukEmptyWeight = DNRowDto.TrcukEmptyWeight,
            TrcukDocGrossWeight = DNRowDto.TrcukDocGrossWeight,
            TruckType = DNRowDto.TruckType,
            DriverCode = DNRowDto.DriverCode
          
        };

        this.dataContext.SAPDeliveryNoteRow.Add(DNRowEntity);
        this.dataContext.SaveChanges();
    }


}

