﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class MadeIn: BaseModel, IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
