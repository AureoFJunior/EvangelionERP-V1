using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcsCrudV1.Models
{
    [Table(name: "tab_products")]
    public class ProductModel
    {
        [Key]
        public int Cod { get; set; }
        public string Name { get; set; }   
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public virtual List<OrderProductModel> OrderProductModel { get; set; }
    }
}
