using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Images : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        //public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
    }
}
