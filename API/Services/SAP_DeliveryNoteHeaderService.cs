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
    void Save(SAP_DeliveryNoteHeaderDto DNHeaderDto);
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

    public void Save(SAP_DeliveryNoteHeaderDto DNHeaderDto)
    {

        SAP_DeliveryNoteHeader_Entity DNHEntity = new SAP_DeliveryNoteHeader_Entity
        {

            DN_Id = DNHeaderDto.DN_Id,
            DN_No= DNHeaderDto.DN_No,
            DN_Series= DNHeaderDto.DN_Series,
            DN_DocEntry = DNHeaderDto.DN_DocEntry,
            DN_DocStatus = DNHeaderDto.DN_DocStatus,
            DN_Date = DNHeaderDto.DN_Date,
            DN_DueDate= DNHeaderDto.DN_DueDate,
            DN_PostingDate= DNHeaderDto.DN_PostingDate,
            DN_TaxDate= DNHeaderDto.DN_TaxDate,
            Cust_Code= DNHeaderDto.Cust_Code,
            Cust_Name= DNHeaderDto.Cust_Name,
            Contct_Code= DNHeaderDto.Contct_Code,
            Curr_Type= DNHeaderDto.Curr_Type,
            Price_Code= DNHeaderDto.Price_Code,
            Ship_Code= DNHeaderDto.Ship_Code,
            Ship_Address= DNHeaderDto.Ship_Address,
            Remarks= DNHeaderDto.DN_Remarks,
            Discount= DNHeaderDto.Discount,
            VAT= DNHeaderDto.VAT,
            NetAmount= DNHeaderDto.NetAmount,
            TotalAmount= DNHeaderDto.TotalAmount,
            DN_OwnerCode= DNHeaderDto.DN_OwnerCode,
            DN_Remarks= DNHeaderDto.DN_Remarks
        };


        this.dataContext.SAP_DeliveryNote_Header.Add(DNHEntity);
        this.dataContext.SaveChanges();
    }


}

