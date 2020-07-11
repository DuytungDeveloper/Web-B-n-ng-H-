using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Images : BaseModel, IBaseModel
    {
        public int Id { get; set; }
     
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
