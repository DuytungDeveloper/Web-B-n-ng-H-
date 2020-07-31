using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class District : LocationModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 2)]
        public int CityId { get; set; } // thành phố /
        public virtual City City { get; set; }
        public List<Address> Address { get; set; }
        public List<Ward> Wards { get; set; }
    }
}
