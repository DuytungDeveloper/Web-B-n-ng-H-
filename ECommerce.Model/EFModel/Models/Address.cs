using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Address : BaseModel, IBaseModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int WardId { get; set; } // phường xã 
        public virtual Ward Ward { get; set; }
        public int Status { get; set; }
    }
}
