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
        public FinancialModel() { }
        public FinancialModel(int cod, decimal totalValue, DateTime inclusionDate)
        {
            Cod = cod;
            TotalValue = totalValue;
            InclusionDate = inclusionDate;
        }

        [Key]
        public int Cod { get; set; }
        public decimal TotalValue { get; set; } 
        public DateTime InclusionDate { get; set; } 
    }
}
