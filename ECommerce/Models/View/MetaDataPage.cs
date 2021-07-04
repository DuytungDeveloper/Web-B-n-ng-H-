using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model;
using ECommerce.Model.EFModel.Models;

namespace ECommerce.Models.View
{
    public class MetaDataPage
    {
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        //[Required]
        //[RegularExpression(@"^[a-z0-9-]+$")]
        //[Display(Name = "SEO friendly url: only lowercase, number and dash (-) character allowed")]
        //public string Slug { get; set; }

        //[Required]
        //public string Title { get; set; }
        //[Required]
        //public string Author { get; set; }
        //[RegularExpression(@"^[0-9]*$")]
        //[Display(Name = "Google+ Id of the author (for picture in search results)")]
        //public string GooglePlusId { get; set; }
        //[Required]
        //public float SortOrder { get; set; }

        //[Display(Name = "Comma-separated list of keywords for search engines")]
        //public string Keywords { get; set; }

        //[Required]
        //[Display(Name = "Content in Markdown format")]
        //public string Markdown { get; set; }
        //[Display(Name = "Last Modified On")]
        //public DateTime Modified { get; set; }

        //[Required]
        //[Display(Name = "Exclude this content from search engine results")]
        //public bool NoSearch { get; set; }
    }
}
