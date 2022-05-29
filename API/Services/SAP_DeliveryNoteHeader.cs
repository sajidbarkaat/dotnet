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

public interface ISAP_DeliveryNoteHeaderService
{
    Task<IEnumerable<SAP_DeliveryNoteHeaderEntity>> GetAll();
}
public class SAP_DeliveryNoteHeaderService : ISAP_DeliveryNoteHeaderService
{
    protected readonly ILogger<SAP_DeliveryNoteHeaderService> logger;
    protected readonly TUDataContext dataContext;
    protected readonly ITokenService tokenService;


}

