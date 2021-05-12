using ECommerce.Model.EFModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class ProductViewModel : Product
    {
        public new string Price { get; set; }
    }
}
