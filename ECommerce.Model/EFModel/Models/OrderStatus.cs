using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class OrderStatus : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Column(Order = 2)]
        public string Desription { get; set; }
        public List<Order> Orders { get; set; }

    }
}
