using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public int? AddressId { get; set; }
        public string Hobby { get; set; }
        public DateTime? Created { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
