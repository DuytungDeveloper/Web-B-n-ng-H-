using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Address : BaseModel, IBaseModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
        public int WardId { get; set; }
        public virtual Ward Ward { get; set; }
        public int Status { get; set; }
    }
}
