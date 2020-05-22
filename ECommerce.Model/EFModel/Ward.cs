using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Ward
    {
        public Ward()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
