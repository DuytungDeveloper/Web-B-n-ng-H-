using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel.Models
{
    public partial class OrderStatus : BaseModel, IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desription { get; set; }
        public int Status { get; set; }
    }
}
