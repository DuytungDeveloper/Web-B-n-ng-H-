using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Url { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public string Images { get; set; }
        public string Videos { get; set; }
        public string Note { get; set; }
        public string MetaTags { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
