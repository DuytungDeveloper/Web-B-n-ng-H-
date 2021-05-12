using ECommerce.Model.EFModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class ProductComponentViewModel
    {
        public int TypeView { get; set; }
        public Product Product { get; set; }
    }
}
