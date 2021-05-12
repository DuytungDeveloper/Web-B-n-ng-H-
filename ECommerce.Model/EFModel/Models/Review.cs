using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Review : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        [Column(Order = 1)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        /// <summary>
        /// Tài khoản khách
        /// </summary>
        [Column(Order = 2)]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        /// <summary>
        /// Nội dung bình luận
        /// </summary>
        [Column(Order = 3)]
        public string Message { get; set; }
        /// <summary>
        /// điểm đánh giá
        /// </summary>
        [Column(Order = 4)]
        public float Point { get; set; }
    }
}
