using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Order : BaseModel, IBaseModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        [Required]
        public string Phone { get; set; }
        
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string ReceiverInfo { get; set; }
        public string Detail { get; set; }
        public int? OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public int Status { get; set; }
    }
}
