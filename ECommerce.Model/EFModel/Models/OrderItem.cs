﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class OrderItem : BaseModel, IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        public float CurrentPrice { get; set; }
        public int Status { get; set; }
    }
}
