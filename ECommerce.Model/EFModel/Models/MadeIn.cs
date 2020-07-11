using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel.Models
{
    public partial class MadeIn: BaseModel, IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
