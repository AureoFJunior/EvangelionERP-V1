using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvangelionERP.Models
{
    [Table(name: "tab_financial")]
    public class FinancialModel
    {
        [Key]
        public int Cod { get; set; }
        public byte? Status { get; set; }
        public decimal TotalValue { get; set; } 
        public decimal ProductsQuantity { get; set; }
        public bool FlOutput { get; set; }
        public virtual List<OrderProductModel> OrderProductModel { get; set; }

    }
}
