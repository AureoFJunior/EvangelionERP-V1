﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcsCrudV1.Models
{
    [Table(name: "tab_order")]
    public class OrderModel
    {
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