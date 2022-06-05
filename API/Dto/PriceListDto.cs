using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto;
public class PriceListDto
    {
        [Required]
        public int PriceList_Id { get; set; }

        [Required]
        public string PriceList_Name { get; set; }

        [Required]
        public string PriceList_Code { get; set; }

        [Required]
        public string Item_Code { get; set; }

        [Required]
        public double UnitPrice { get; set; }
    }

