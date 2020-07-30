using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Product_Function : BaseModel, IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Function")]
        public int FunctionId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Function Function { get; set; }
    }
}
