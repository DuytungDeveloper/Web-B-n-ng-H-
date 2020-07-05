using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel.Models
{
    public partial class BrandProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
    }
}
