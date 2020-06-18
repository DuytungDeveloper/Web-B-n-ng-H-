using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class HuntingCase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
    }
}
