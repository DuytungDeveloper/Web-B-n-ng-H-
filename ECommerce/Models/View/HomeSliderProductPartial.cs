using ECommerce.Model.EFModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class HomeSliderProductPartial
    {
        public List<Product> sanPhamChayNhat { get; set; }
        public List<Product> sanPhamGiamGia { get; set; }
        public List<Product> sanPhamMoiNhat { get; set; }
        public List<Product> dealHoi { get; set; }
    }
}
