using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class City : BaseModel, IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Status { get; set; }
        public List<Address> Address { get; set; }
        public List<District> Districts { get; set; }


    }
}
