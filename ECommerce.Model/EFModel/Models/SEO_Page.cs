using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class SEO_Page : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }


        [Required]
        [RegularExpression(@"^[a-z0-9-]+$")]
        [Display(Name = "SEO friendly url: only lowercase, number and dash (-) character allowed")]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [RegularExpression(@"^[0-9]*$")]
        [Display(Name = "Google+ Id of the author (for picture in search results)")]
        public string GooglePlusId { get; set; }
        [Required]
        public float SortOrder { get; set; }

        [Display(Name = "Comma-separated list of keywords for search engines")]
        public string Keywords { get; set; }

        [Required]
        [Display(Name = "Content in Markdown format")]
        public string Markdown { get; set; }
        [Display(Name = "Last Modified On")]
        public DateTime Modified { get; set; }

        [Required]
        [Display(Name = "Exclude this content from search engine results")]
        public bool NoSearch { get; set; }
    }
}
