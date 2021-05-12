using ECommerce.Model.EFModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class ProductDetailView
    {
        public Product ProductDetail { get; set; }
        public List<Product> SanPhamCungLoai { get; set; }
        public List<Product> SanPhamTuongTu { get; set; }
        public List<Product> SanPhamGiamGia { get; set; }
        public List<Category> DanhMucKhac { get; set; }
        public List<Product> DongHoPhienBanDacBiet { get; set; }
        public List<Product> DongHoPhienBanGioiHan { get; set; }
        public List<BrandProduct> AllBrandProduct { get; set; }
    }
}
