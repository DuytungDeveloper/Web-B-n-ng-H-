﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class SystemInfomation : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
