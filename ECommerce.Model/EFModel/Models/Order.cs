using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Order : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        /// <summary>
        /// Code giảm giá chẳng hạn
        /// </summary>
        [Column(Order = 1)]
        public string Code { get; set; }
        /// <summary>
        /// Ghi chú của khách hàng
        /// </summary>
        [Column(Order = 2)]
        public string Note { get; set; }
        /// <summary>
        /// Số điện thoại khách
        /// </summary>
        [Required]
        [Column(Order = 3)]
        public string Phone { get; set; }

        /// <summary>
        /// Tài khoản khách
        /// </summary>
        [Column(Order = 4)]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        /// <summary>
        /// Thông tin người nhận
        /// </summary>
        [Column(Order = 5)]
        public string ReceiverInfo { get; set; }
        /// <summary>
        /// Trạng thái đơn hàng
        /// </summary>
        [Column(Order = 6)]
        public int OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }

    }
}
