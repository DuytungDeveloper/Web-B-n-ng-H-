using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Product : BaseModel
    {

        [Column(Order = 0)]
        public int Id { get; set; }

        //public virtual Origin Origin { get; set; }
        //public int? HuntingCaseId { get; set; }
        //public virtual HuntingCase HuntingCase { get; set; }

        //public int? ChatelaineId { get; set; }
        //public virtual Chatelaine Chatelaine { get; set; }




        //public int? HemId { get; set; }
        //public virtual Hem Hem { get; set; }



        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
        /// <summary>
        /// Video giới thiệu sản phẩm
        /// </summary>
        [Column(Order =3)]
        public string Video { get; set; }
        /// <summary>
        /// Url của sản phẩm (Friendly URL để SEO)
        /// </summary>
        [Column(Order = 2)]
        public string Url { get; set; }
        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        [Required]
        [Column(Order = 4)]
        public int Price { get; set; }
        /// <summary>
        /// Giá khuyến mãi
        /// </summary>
        [Column(Order = 5)]
        public int? PriceDiscount { get; set; }
        /// <summary>
        /// Ngày bắt đầu khuyến mãi
        /// </summary>
        [Column(Order = 6)]
        public DateTime? DiscountDateFrom { get; set; }
        /// <summary>
        /// ngày kết thúc khuyến mãi
        /// </summary>
        [Column(Order = 7)]
        public DateTime? DiscountDateTo { get; set; }





        //public string Guarantee { get; set; }
        /// <summary>
        /// Đặc điểm của sản phẩm (mô tả thêm)
        /// </summary>
        [Column(Order = 8)]
        public string Characteristics { get; set; }

        /// <summary>
        /// Mô tả ngắn
        /// </summary>
        [Column(Order = 9)]
        public string DescriptionShort { get; set; }
        /// <summary>
        /// Mô tả chi tiết sản phẩm
        /// </summary>
        [Column(Order = 10)]
        public string DescriptionFull { get; set; }


        #region Thành phần tìm kiếm và thông số kỹ thuật của sản phẩm
        /// <summary>
        /// Sku sản phẩm
        /// </summary>
        [Column(Order = 11)]
        public string Sku { get; set; }
        /// <summary>
        /// Thương hiệu của sản phẩm
        /// </summary>
        [Column(Order = 12)]
        public int? BrandProductId { get; set; }
        public virtual BrandProduct BrandProduct { get; set; }
        /// <summary>
        /// Số hiệu sản phẩm gốc (Số seri)
        /// </summary>
        [Column(Order = 13)]
        public string OriginNumber { get; set; }
        ///// <summary>
        ///// Giới tính
        ///// </summary>
        //public bool Sex { get; set; }
        /// <summary>
        /// Loại máy
        /// </summary>
        [Column(Order = 14)]
        public int? MachineId { get; set; }
        public virtual Machine Machine { get; set; }
        /// <summary>
        /// Thời gian bảo hành quốc tế (tính bằng năm)
        /// </summary>
        [Column(Order = 15)]
        public float? InternationalWarrantyTime { get; set; }
        /// <summary>
        /// Thời gian bảo hành tại cửa hàng (tính bằng năm)
        /// </summary>
        [Column(Order = 16)]
        public float? StoreWarrantyTime { get; set; }
        /// <summary>
        /// đường kính mặt đồng hồ
        /// </summary>
        [Column(Order = 17)]
        public string Diameter { get; set; }
        /// <summary>
        /// Độ dày
        /// </summary>
        [Column(Order = 18)]
        public float? ThicknessOfClass { get; set; }
        /// <summary>
        /// Loại niềng
        /// </summary>
        [Column(Order = 19)]
        public int? BandId { get; set; }
        public virtual Band Band { get; set; }
        /// <summary>
        /// Loại dây
        /// </summary>
        [Column(Order = 20)]
        public int? StrapId { get; set; }
        public virtual Strap Strap { get; set; }
        /// <summary>
        /// màu mặt kính
        /// </summary>
        [Column(Order = 21)]
        public int? ColorClockFaceId { get; set; }
        public virtual ColorClockFace ColorClockFace { get; set; }

        /// <summary>
        /// Nơi sản xuất
        /// </summary>
        [Column(Order = 22)]
        public int? MadeInId { get; set; }
        public virtual MadeIn MadeIn { get; set; }
        /// <summary>
        /// Phong cách
        /// </summary>
        [Column(Order = 23)]
        public int? StyleId { get; set; }
        public virtual Style Style { get; set; }
        /// <summary>
        /// Chống thấm
        /// </summary>
        [Column(Order = 24)]
        public int? WaterproofId { get; set; }
        public virtual Waterproof Waterproof { get; set; }
        /// <summary>
        /// Phân loại theo danh mục
        /// </summary>
        [Column(Order = 25)]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Product_Function> Product_Function { get; set; }
        #endregion

        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual List<Product_ProductStatus> Product_ProductStatus { get; set; }
        public virtual List<Product_Media> Product_Media { get; set; }
        public virtual List<Review> Reviews { get; set; }
        [NotMapped]
        public float? Point { 
            get {
                float rs = 0;
                if (Reviews != null && Reviews.Count > 0)
                {
                    for (int i = 0; i < Reviews.Count; i++)
                    {
                        rs += Reviews[i].Point;
                    }
                    rs = rs / Reviews.Count;
                }
                return rs;
            } set {
                Point = value;
            } }
        [NotMapped]
        public int Qty { get; set; }
        [Column(Order = 26)]
        public int ViewsCount { get; set; }
        /// <summary>
        /// Số lượng sản phẩm trong kho
        /// </summary>
        [Column(Order = 27)]
        public int QtyInWareHouse { get; set; }
        [Column(Order = 28)]
        public string TitleSEO { get; set; }
        [Column(Order = 29)]
        public string KeyWordSEO { get; set; }
        [Column(Order = 30)]
        public string DescriptionShortSEO { get; set; }
    }
}
