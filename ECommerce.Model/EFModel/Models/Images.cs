using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Images : BaseModel, IBaseModel
    {
        [Required]
        public int Id { get; set; }
     
        public int? IdProduct { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
