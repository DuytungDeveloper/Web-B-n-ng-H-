using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class ProductsOnFirstPage : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 0)]
        public int ProductId { get; set; }
        public int ViewTypeId { get; set; }
        public Product Product { get; set; }


    }
}
