using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class ProductOrder
    {
        public int Qty { get; set; }
        public int ProductId { get; set; }
    }
    public class SaveOrderViewModel
    {
        [Required]
        public List<ProductOrder> Products { get; set; }
    }
}
