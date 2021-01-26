using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Product_Media
    {
        public int ProductId { get; set; }
        public int MediaId { get; set; }
        /// <summary>
        /// Dùng để sắp xếp hiển thị
        /// </summary>
        //public int? ShowIndex { get; set; }
        public virtual Media Media { get; set; }
        public virtual Product Product { get; set; }
    }
}
