using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Order : BaseModel, IBaseModel
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Code giảm giá chẳng hạn
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Ghi chú của khách hàng
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Số điện thoại khách
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Tài khoản khách
        /// </summary>
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        /// <summary>
        /// Thông tin người nhận
        /// </summary>
        public string ReceiverInfo { get; set; }
        /// <summary>
        /// Trạng thái đơn hàng
        /// </summary>
        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }

    }
}
