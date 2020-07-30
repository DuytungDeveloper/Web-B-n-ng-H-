using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Ward : BaseModel, IBaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DistrictId { get; set; } // Quận/ huyện
        public virtual District District { get; set; }
        public int Status { get; set; }
        public List<Address> Address { get; set; }
    }
}
