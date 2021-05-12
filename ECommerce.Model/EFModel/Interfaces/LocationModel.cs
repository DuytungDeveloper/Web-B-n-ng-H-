using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Model.EFModel
{
    public class LocationModel : BaseModel
    {
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
        public int Sort { get; set; }
    }
}
