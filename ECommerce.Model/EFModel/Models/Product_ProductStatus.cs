using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public class Product_ProductStatus
    {
        [Column(Order = 0)]
        public int ProductId { get; set; }
        [Column(Order = 1)]
        public int ProductStatusId { get; set; }

        public virtual ProductStatus ProductStatus { get; set; }
        public virtual Product Product { get; set; }
    }
}
