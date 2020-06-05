using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Model.EFViewModel
{
    public class ProductViewModel
    {
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
        public string Name { get; set; }
        public string Value { get; set; }
        public int Type  { get; set; }
        public DateTime? Created { get; set; }
    }
}
