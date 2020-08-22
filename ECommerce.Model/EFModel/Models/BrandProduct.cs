using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class BrandProduct : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Column(Order = 2)]
        // Mô tả hoặc giới thiệu sơ về nhãn hàng này
        public string Description { get; set; }
        public List<Product> Products { get; set; }

    }
}
