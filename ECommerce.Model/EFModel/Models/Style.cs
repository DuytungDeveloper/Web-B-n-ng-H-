﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Style : BaseModel, IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } // Unique
        public int Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
