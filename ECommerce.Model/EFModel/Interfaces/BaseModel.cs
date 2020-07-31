using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Model
{
    public interface IBaseModel
    {
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public int Status { get; set; }
    }
    public class BaseModel : IBaseModel
    {
        [Column(Order = 90)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateDate { get; set; }
        [Column(Order = 91)]
        public string? CreateBy { get; set; }
        [Column(Order = 92)]

        public DateTime? UpdateDate { get; set; }
        [Column(Order = 93)]

        public string UpdateBy { get; set; }
        [Column(Order = 94)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Status { get; set; }
    }
}
