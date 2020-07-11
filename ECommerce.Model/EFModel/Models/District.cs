using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class District : BaseModel, IBaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CityId { get; set; } // thành phố /
        public virtual City City { get; set; }
        public int Status { get; set; }
    }
}
