using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvangelionERP.Models
{
    [Table(name: "tab_products")]
    public class ProductModel
    {
        public ProductModel() { }
        public ProductModel(int cod, string name, decimal price, decimal quantity, List<OrderProductModel> orderProductModel)
        {
            Cod = cod;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        [Key]
        public int Cod { get; set; }
        public string Name { get; set; }   
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public virtual List<OrderProductModel> OrderProductModel { get; set; }
    }
}
