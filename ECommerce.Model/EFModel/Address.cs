using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public DateTime? Created { get; set; }
        public int? Status { get; set; }
    }
}
