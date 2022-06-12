using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;
public class SAP_DeliveryNoteHeaderDto
{
    [Required]
    public int DN_Id { get; set; }

    [Required]
    public string DN_No { get; set; }

    [Required]
    public int DN_Series { get; set; }

    [Required]
    public int DN_DocEntry { get; set; }

    [Required]
    public string DN_DocStatus { get; set; }

    [Required]
    public DateTime DN_Date { get; set; }

    [Required]
    public DateTime DN_DueDate { get; set; }

    [Required]
    public DateTime DN_PostingDate { get; set; }

    [Required]
    public DateTime DN_TaxDate { get; set; }

    [Required]
    public string Cust_Code { get; set; }

    [Required]
    public string Cust_Name { get; set; }

    [Required]
    public int Contct_Code { get; set; }

    [Required]
    public string Curr_Type { get; set; }

    [Required]
    public int Price_Code { get; set; }

    [Required]
    public int Ship_Code { get; set; }

    [Required]
    public string Ship_Address { get; set; }

    [Required]
    public string Remarks { get; set; }

    [Required]
    public decimal Discount { get; set; }

    [Required]
    public decimal VAT { get; set; }

    [Required]
    public decimal NetAmount { get; set; }

    [Required]
    public decimal TotalAmount { get; set; }

    [Required]
    public int DN_OwnerCode { get; set; }

    [Required]
    public string DN_Remarks { get; set; }

}

