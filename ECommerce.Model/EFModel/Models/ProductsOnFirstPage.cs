using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class ProductsOnFirstPage
    {

        [Column(Order = 1)]
        public int ViewTypeId { get; set; }
        [Column(Order = 2)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Column(Order = 3)]
        public int OrderId { get; set; }
    }
}
