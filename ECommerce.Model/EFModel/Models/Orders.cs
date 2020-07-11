using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Orders : BaseModel, IBaseModel
    {
        [Required]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        [Required]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string Phone { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string ReceiverInfo { get; set; }
        public string Detail { get; set; }
        public int IdOrderStatus { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public int Status { get; set; }
    }
}
