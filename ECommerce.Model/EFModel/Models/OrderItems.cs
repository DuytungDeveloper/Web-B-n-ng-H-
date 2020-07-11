using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class OrderItems : BaseModel, IBaseModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public virtual Orders Orders { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int Status { get; set; }
    }
}
