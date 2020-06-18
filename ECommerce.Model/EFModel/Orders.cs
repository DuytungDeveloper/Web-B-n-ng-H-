using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Orders
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public int? CustomerId { get; set; }
        public string ReceiverInfo { get; set; }
        public string Detail { get; set; }
        public int? IdOrderStatus { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }
    }
}
