using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class OrderItem : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        [Column(Order = 2)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        [Column(Order = 3)]
        public int Quantity { get; set; }
        [Column(Order = 4)]
        public int CurrentPrice { get; set; }
    }
}
