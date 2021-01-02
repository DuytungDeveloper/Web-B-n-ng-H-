using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Areas.Admin.Models
{
    public class FilterResultViewModel<T> where T : class
    {
        public int draw { get; set; }
        /// <summary>
        /// tổng toàn bộ
        /// </summary>
        public int recordsTotal { get; set; } // tổng toàn bộ
        /// <summary>
        /// tổng sau khi lọc
        /// </summary>
        public int recordsFiltered { get; set; } // tổng sau khi lọc
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public T data { get; set; }
    }
}
