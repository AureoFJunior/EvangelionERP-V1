using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvangelionERP.Models
{
    [Table(name: "tab_order")]
    public class OrderModel
    {
        public OrderModel() { }
        public OrderModel(int cod, DateTime creationDate, byte? status, decimal totalValue, decimal productsQuantity, bool flOutput)
        {
            Cod = cod;
            CreationDate = creationDate;
            Status = status;
            TotalValue = totalValue;
            ProductsQuantity = productsQuantity;
            FlOutput = flOutput;
        }

        [Key]
        public int Cod { get; set; }
        public DateTime CreationDate { get; set; }
        public byte? Status { get; set; }
        public decimal TotalValue { get; set; } 
        public decimal ProductsQuantity { get; set; }
        public bool FlOutput { get; set; }
        public virtual List<OrderProductModel> OrderProductModel { get; set; }

    }
}
