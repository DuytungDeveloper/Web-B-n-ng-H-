using ECommerce.Model.EFModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class HomeDataView
    {
        public HomeSliderProductPartial HomeSliderProductPartial { get; set; }
        public List<Product> DongHoNam { get; set; }
        public List<Product> DongHoNu { get; set; }
        public List<Product> DongHoCap { get; set; }
        public List<Product> DongHoTreEm { get; set; }
        public List<Product> DongHoPhienBanDacBiet { get; set; }
        public List<Product> DongHoPhienBanGioiHan { get; set; }
        public List<BrandProduct> AllBrandProduct { get; set; }
        public List<SystemInfomation> AllSystemInfo { get; set; }


        public List<Product> DongHoNam_BanChayNhat { get; set; }
        public List<Product> DongHoNam_NhieuNguoiXem { get; set; }

        public List<Product> DongHoNu_BanChayNhat { get; set; }
        public List<Product> DongHoNu_NhieuNguoiXem { get; set; }


        public List<Product> DongHoTreEm_BanChayNhat { get; set; }
        public List<Product> DongHoTreEm_NhieuNguoiXem { get; set; }



        public List<Product> DongHoPhienBanDacBiet_BanChayNhat { get; set; }
        public List<Product> DongHoPhienBanDacBiet_NhieuNguoiXem { get; set; }

        public List<Product> DongHoPhienBanGioiHan_BanChayNhat { get; set; }
        public List<Product> DongHoPhienBanGioiHan_NhieuNguoiXem { get; set; }

        public List<Product> DongHoCap_BanChayNhat { get; set; }
        public List<Product> DongHoCap_NhieuNguoiXem { get; set; }
    }
}
