using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Index(nameof(PriceList_Code), IsUnique = true)]
    public class SAP_PriceListEntity
    {
        [Key]
        public int PriceList_Id { get; set; }

        [Required]
        public string PriceList_Name { get; set; }

        [Required]
        public string PriceList_Code { get; set; }

        [Required]
        public string Item_Code { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }

}
