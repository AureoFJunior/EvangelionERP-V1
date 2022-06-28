using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcsCrudV1.Models
{
    public class OrderProductViewModel
    {
        [Key]
        public int Cod { get; set; }
        public int OrderCod { get; set; }
        public int ProductCod { get; set; }   
        public decimal Quantity { get; set; }   
        public decimal Price { get; set; }   
        public string Name { get; set; }
    }
}
