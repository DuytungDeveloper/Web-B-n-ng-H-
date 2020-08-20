using ECommerce.Model.EFModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class OrderViewModel
    {
        [Required]
        public List<Product> Products { get; set; }
        public BigInteger Total
        {
            get
            {
                if(Products == null || Products.Count == 0)
                {
                    return 0;
                }
                BigInteger total = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    var pro = Products[i];
                    if (pro.DiscountDateTo > new DateTime() && pro.PriceDiscount.HasValue)
                    {
                        total += ((BigInteger)pro.PriceDiscount.Value * pro.Qty);
                    }
                    else
                    {
                        total += (BigInteger)pro.Price * pro.Qty;
                    }
                }
                BigInteger tax10 = total * 10 / 100;
                total += tax10;
                return total;
            }
        }
        public BigInteger Thue
        {
            get
            {
                if (Products == null || Products.Count == 0)
                {
                    return 0;
                }
                BigInteger total = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    var pro = Products[i];
                    if (pro.DiscountDateTo > new DateTime() && pro.PriceDiscount.HasValue)
                    {
                        total += ((BigInteger)pro.PriceDiscount.Value * pro.Qty);
                    }
                    else
                    {
                        total += (BigInteger)pro.Price * pro.Qty;
                    }
                }
                BigInteger tax10 = total * 10 / 100;
                return tax10;
            }
        }
        public BigInteger TamTinh
        {
            get
            {
                if (Products == null || Products.Count == 0)
                {
                    return 0;
                }
                BigInteger total = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    var pro = Products[i];
                    if (pro.DiscountDateTo > new DateTime() && pro.PriceDiscount.HasValue)
                    {
                        total += ((BigInteger)pro.PriceDiscount.Value * pro.Qty);
                    }
                    else
                    {
                        total += (BigInteger)pro.Price * pro.Qty;
                    }
                }
                return total;
            }
        }
    }
}
