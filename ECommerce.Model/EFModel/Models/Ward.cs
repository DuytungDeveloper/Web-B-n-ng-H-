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
        public int DistrictId { get; set; }
        public virtual District City { get; set; }
        public int Status { get; set; }
    }
}
