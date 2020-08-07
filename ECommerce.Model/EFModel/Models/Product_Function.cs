using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Product_Function
    {
        [Column(Order = 0)]
        public int ProductId { get; set; }
        [Column(Order = 1)]
        public int FunctionId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Function Function { get; set; }
    }
}
