using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Desription { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
