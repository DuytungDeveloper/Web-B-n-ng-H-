using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Images
    {
        public int Id { get; set; }
        public int? IdProduct { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
    }
}
