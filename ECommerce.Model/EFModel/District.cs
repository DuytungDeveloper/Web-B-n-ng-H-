using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class District
    {
        public District()
        {
            Address = new HashSet<Address>();
            Ward = new HashSet<Ward>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Ward> Ward { get; set; }
    }
}
