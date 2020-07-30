﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class OrderStatus : BaseModel, IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Desription { get; set; }
        public int Status { get; set; }
        public List<Order> Orders { get; set; }

    }
}
