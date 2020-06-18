using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public int? Status { get; set; }
    }
}
