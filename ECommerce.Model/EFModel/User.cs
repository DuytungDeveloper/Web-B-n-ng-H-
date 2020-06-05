using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? DiscountPrice { get; set; }
        public int? SalePrice { get; set; }
        public string Images { get; set; }
        public string Video { get; set; }
        public string Note { get; set; }
        public string MetaTags { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
