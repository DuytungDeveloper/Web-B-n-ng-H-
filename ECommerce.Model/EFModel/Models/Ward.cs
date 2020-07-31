using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Ward : LocationModel
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public int DistrictId { get; set; } // Quận/ huyện
        public virtual District District { get; set; }
        public List<Address> Address { get; set; }
    }
}
