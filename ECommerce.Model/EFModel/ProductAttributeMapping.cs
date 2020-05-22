using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class ProductAttributeMapping
    {
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
