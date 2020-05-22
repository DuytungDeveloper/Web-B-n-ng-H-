using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
            District = new HashSet<District>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<District> District { get; set; }
    }
}
