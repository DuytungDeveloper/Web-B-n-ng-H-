using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Address : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public string Street { get; set; }
        [Column(Order = 2)]
        public int? WardId { get; set; } // phường xã 
        [Column(Order = 3)]
        public int? DistrictId { get; set; } // Quận huyện
        [Column(Order = 4)]
        public int? CityId { get; set; } // Thành phố
        public virtual Ward Ward { get; set; }
        public virtual District District { get; set; }
        public virtual City City { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }
    }
}
