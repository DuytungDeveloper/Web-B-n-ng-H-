﻿using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Customer
    {
        public int Id { get; set; }
        public int? AddressId { get; set; }
        public string Hobby { get; set; }
        public DateTime? Created { get; set; }
        public int? Status { get; set; }
    }
}
