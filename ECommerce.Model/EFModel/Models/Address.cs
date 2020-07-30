using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Address : BaseModel, IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public int? WardId { get; set; } // phường xã 
        public int? DistrictId { get; set; } // Quận huyện
        public int? CityId { get; set; } // Thành phố
        public virtual Ward Ward { get; set; }
        public virtual District District { get; set; }
        public virtual City City { get; set; }
        public int Status { get; set; }
    }
}
