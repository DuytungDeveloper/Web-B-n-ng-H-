using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model;
using ECommerce.Model.EFModel.Models;

namespace ECommerce.Models.View
{
    public class StaticData
    {
        private static List<SystemInfomation> _SystemInfos { get; set; }
        public static List<SystemInfomation> SystemInfos
        {
            get
            {
                if (_SystemInfos == null || _SystemInfos.Count == 0)
                {

                    _SystemInfos = new List<SystemInfomation>() {
                        new SystemInfomation() { Type = "Email", Value = "Tronghoang0803@gmail.com" ,Status = 1},
                        new SystemInfomation() { Type = "Address", Value = "Khu nhà ở cao cấp Phú Mỹ Hưng", Status = 1 },
                        new SystemInfomation() { Type = "PhoneMainContact", Value = "0774232359", Status = 1 },
                        new SystemInfomation() { Type = "MainTittle", Value = "Pwatch - Đỉnh Cao Trang Sức", Status = 1 },
                        new SystemInfomation() { Type = "WarrantyPolicy", Value = "Cho bạn luôn", Status = 1 },
                        new SystemInfomation() { Type = "WebIcon", Value = "aldk;sfgja;lkdjg;áldjkf", Status = 1 },
                        new SystemInfomation() { Type = "Facebook", Value = "https://www.facebook.com/trong.hoang.3386", Status = 1 },
                        new SystemInfomation() { Type = "GooglePlus", Value = "https://www.facebook.com/trong.hoang.3386", Status = 1 },
                        new SystemInfomation() { Type = "Twitter", Value = "https://www.facebook.com/trong.hoang.3386", Status = 1 }
                    };
                }
                return _SystemInfos;
            }
            set { _SystemInfos = value; }
        }
    }
}
