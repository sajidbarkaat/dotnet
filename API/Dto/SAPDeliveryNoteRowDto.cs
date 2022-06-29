using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;
public class SAPDeliveryNoteRowDto
{
    [Required]
    public int DNRId { get; set; }

    [Required]
    public string DNNo { get; set; }

    [Required]
    public string ItemCode { get; set; }

    [Required]
    public string ItemName { get; set; }

    [Required]
    public decimal PriceBefDiscount { get; set; }

    [Required]
    public decimal DiscountPercent { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public string VATCode { get; set; }

    [Required]
    public string WareHouseCode { get; set; }

    [Required]
    public string UOMName { get; set; }

    [Required]
    public string UOMGroupCode { get; set; }


    [Required]
    public string UOMCode { get; set; }


    [Required]
    public string TrcukName { get; set; }

    [Required]
    public string TruckEnglishName { get; set; }

    [Required]
    public string TruckLicensePlate { get; set; }

    [Required]
    public decimal TrcukEmptyWeight { get; set; }

    [Required]
    public decimal TrcukDocGrossWeight { get; set; }

    [Required]
    public string TruckType { get; set; }

    [Required]
    public string DriverCode { get; set; }

}

