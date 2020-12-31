using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Areas.Admin.Models
{
    public class FilterViewModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public FilterSearchViewModel search { get; set; }
        public List<FilterOrderViewModel> order { get; set; }
        public IEnumerable<FilterColumnViewModel> columns { get; set; }
    }

    public class FilterSearchViewModel
    {
        public string value { get; set; } = "";
        public bool regex { get; set; }
    }
    public class FilterOrderViewModel
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
    public class FilterColumnViewModel
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public FilterSearchViewModel search { get; set; }
    }
}
