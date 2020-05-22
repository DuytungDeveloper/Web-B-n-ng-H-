using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Address
    {
        public Address()
        {
            Customer = new HashSet<Customer>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int WardId { get; set; }
        public DateTime? Created { get; set; }

        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
