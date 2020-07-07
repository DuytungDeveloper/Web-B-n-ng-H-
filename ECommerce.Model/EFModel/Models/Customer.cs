using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Customer : BaseModel, IBaseModel
    {
        public int Id { get; set; }
        public int? AddressId { get; set; }
        public string Hobby { get; set; }
        public int? Status { get; set; }
    }
}
