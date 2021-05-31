using ECommerce.Middlewares;
using ECommerce.Model.EFModel.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Helpers
{
    public class Common
    {

        public enum SanPhamTrangDauViewType
        {
            Limit = 10,

            BanChayNhat = 1,
            DangGiamGia = 2,
            MauMoi = 3,
            DealHoi = 4,

            DongHoNam_BanChayNhat = 5,
            DongHoNam_NhieuNguoiXem = 6,

            DongHoNu_BanChayNhat = 7,
            DongHoNu_NhieuNguoiXem = 8,

            DongHoTreEm_BanChayNhat = 9,
            DongHoTreEm_NhieuNguoiXem = 10,

            DongHoPhienBanDacBiet_BanChayNhat = 11,
            DongHoPhienBanDacBiet_NhieuNguoiXem = 12,

            DongHoPhienBanGioiHan_BanChayNhat = 13,
            DongHoPhienBanGioiHan_NhieuNguoiXem = 14,

            DongHoCap_BanChayNhat = 15,
            DongHoCap_NhieuNguoiXem = 16,

        }
        public string GetCurrentLang()
        {
            return string.IsNullOrEmpty(Thread.CurrentThread.CurrentCulture.ToString().ToLower()) ? "vi" : Thread.CurrentThread.CurrentCulture.ToString().ToLower();
        }
        /// <summary>
        /// Lấy số lượng sản phẩm trong đơn hàng ra
        /// </summary>
        /// <param name="OrderItems">Danh sách item</param>
        /// <returns></returns>
        public static int GetTotalItemInOrder(List<OrderItem> OrderItems)
        {
            if (OrderItems == null || OrderItems.Count == 0)
            {
                return 0;
            }
            int total = 0;
            for (int i = 0; i < OrderItems.Count; i++)
            {
                var orderItem = OrderItems[i];
                if (orderItem != null && orderItem.Quantity != 0 && orderItem.CurrentPrice != 0)
                {
                    total += orderItem.Quantity;
                }
            }
            return total;
        }
        /// <summary>
        /// Đếm tổng tiền trong đơn hàng
        /// </summary>
        /// <param name="OrderItems"></param>
        /// <returns></returns>
        public static long TotalPrice(List<OrderItem> OrderItems)
        {
            if (OrderItems == null || OrderItems.Count == 0)
            {
                return 0;
            }
            long total = 0;
            for (int i = 0; i < OrderItems.Count; i++)
            {
                var orderItem = OrderItems[i];
                if (orderItem != null && orderItem.Quantity != 0 && orderItem.CurrentPrice != 0)
                {
                    total += (long)orderItem.CurrentPrice * orderItem.Quantity;
                }
            }
            long tax10 = total * 10 / 100;
            total += tax10;
            return total;
        }
    }
}
