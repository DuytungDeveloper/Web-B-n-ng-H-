using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class City : LocationModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        public List<Address> Address { get; set; }
        public List<District> Districts { get; set; }


    }
}
