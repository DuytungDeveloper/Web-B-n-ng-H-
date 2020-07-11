using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class OrderItem : BaseModel, IBaseModel
    {
        [Required]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Orders { get; set; }
       
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int Status { get; set; }
    }
}
