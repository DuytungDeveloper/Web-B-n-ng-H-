using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class ProductAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }
    }
}
