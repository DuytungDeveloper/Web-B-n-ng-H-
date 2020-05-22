using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string ReceiverInfo { get; set; }
        public string Detail { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual OrderStatus StatusNavigation { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
