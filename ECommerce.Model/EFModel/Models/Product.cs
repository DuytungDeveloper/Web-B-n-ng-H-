using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Product : BaseModel, IBaseModel
    {

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
        public string Name { get; set; }
        /// <summary>
        /// Video giới thiệu sản phẩm
        /// </summary>
        public string Video { get; set; }
        /// <summary>
        /// Url của sản phẩm (Friendly URL để SEO)
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        [Required]
        public int Price { get; set; }
        /// <summary>
        /// Giá khuyến mãi
        /// </summary>
        public int PriceDiscount { get; set; }
        /// <summary>
        /// Ngày bắt đầu khuyến mãi
        /// </summary>
        public DateTime DiscountDateFrom { get; set; }
        /// <summary>
        /// ngày kết thúc khuyến mãi
        /// </summary>
        public DateTime DiscountDateTo { get; set; }





        //public string Guarantee { get; set; }
        /// <summary>
        /// Đặc điểm của sản phẩm (mô tả thêm)
        /// </summary>
        public string Characteristics { get; set; }

        /// <summary>
        /// Mô tả ngắn
        /// </summary>
        public string DescriptionShort { get; set; }
        /// <summary>
        /// Mô tả chi tiết sản phẩm
        /// </summary>
        public string DescriptionFull { get; set; }


        #region Thành phần tìm kiếm và thông số kỹ thuật của sản phẩm
        /// <summary>
        /// Sku sản phẩm
        /// </summary>
        public string Sku { get; set; }
        [ForeignKey("BrandProduct")]
        /// <summary>
        /// Thương hiệu của sản phẩm
        /// </summary>
        public int? BrandProductId { get; set; }
        public virtual BrandProduct BrandProduct { get; set; }
        /// <summary>
        /// Số hiệu sản phẩm gốc (Số seri)
        /// </summary>
        public int? OriginNumber { get; set; }
        ///// <summary>
        ///// Giới tính
        ///// </summary>
        [ForeignKey("Machine")]
        //public bool Sex { get; set; }
        /// <summary>
        /// Loại máy
        /// </summary>
        public int? MachineId { get; set; }
        public virtual Machine Machine { get; set; }
        /// <summary>
        /// Thời gian bảo hành quốc tế (tính bằng năm)
        /// </summary>
        public int? InternationalWarrantyTime { get; set; }
        /// <summary>
        /// Thời gian bảo hành tại cửa hàng (tính bằng năm)
        /// </summary>
        public int? StoreWarrantyTime { get; set; }
        /// <summary>
        /// đường kính mặt đồng hồ
        /// </summary>
        public int? Diameter { get; set; }
        /// <summary>
        /// đường kính mặt đồng hồ
        /// </summary>
        public int? ThicknessOfClass { get; set; }
        [ForeignKey("Band")]
        /// <summary>
        /// Loại niềng
        /// </summary>
        public int? BandId { get; set; }
        public virtual Band Band { get; set; }
        [ForeignKey("Strap")]
        /// <summary>
        /// Loại dây
        /// </summary>
        public int? StrapId { get; set; }
        public virtual Strap Strap { get; set; }
        [ForeignKey("ColorClockFace")]
        /// <summary>
        /// màu mặt kính
        /// </summary>
        public int? ColorClockFaceId { get; set; }
        public virtual ColorClockFace ColorClockFace { get; set; }

        [ForeignKey("MadeIn")]
        /// <summary>
        /// Nơi sản xuất
        /// </summary>
        public int? MadeInId { get; set; }
        public virtual MadeIn MadeIn { get; set; }
        [ForeignKey("Style")]
        /// <summary>
        /// Phong cách
        /// </summary>
        public int? StyleId { get; set; }
        public virtual Style Style { get; set; }
        [ForeignKey("Waterproof")]
        /// <summary>
        /// Chống thấm
        /// </summary>
        public int? WaterproofId { get; set; }
        public virtual Waterproof Waterproof { get; set; }
        /// <summary>
        /// chức năng hiện có của sản phẩm
        /// </summary>
        //public int? FunctionId { get; set; }
        public virtual List<Product_Function> Product_Function { get; set; }
        #endregion

        [ForeignKey("ProductStatus")]
        public int ProductStatusId { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }



    }
}
