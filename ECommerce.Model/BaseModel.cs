using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Model
{
    public interface IBaseModel
    {
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
    public class BaseModel:IBaseModel
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string UpdateBy { get; set; }
    }
}
