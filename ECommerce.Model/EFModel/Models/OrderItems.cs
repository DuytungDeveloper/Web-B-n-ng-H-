using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel.Models
{
    public partial class OrderItems
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
