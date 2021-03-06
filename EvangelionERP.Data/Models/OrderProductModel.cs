using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvangelionERP.Models
{
    [Table(name: "tab_orders_itens")]
    public class OrderProductModel
    {
        public OrderProductModel() { }
        public OrderProductModel(int cod, int orderCod,  int productCod, decimal quantity, decimal price, string name, bool? flOutput)
        {
            Cod = cod;
            OrderCod = orderCod;
            ProductCod = productCod;
            Quantity = quantity;
            Price = price;
            Name = name;
            FlOutput = flOutput;
        }

        [Key]
        public int Cod { get; set; }
        public virtual OrderModel Order { get; set; }
        public int OrderCod { get; set; }
        public virtual ProductModel Product { get; set; }
        public int ProductCod { get; set; }   
        public decimal Quantity { get; set; }   
        public decimal Price { get; set; }   
        public string Name { get; set; }
        public bool? FlOutput { get; set; }
    }
}
