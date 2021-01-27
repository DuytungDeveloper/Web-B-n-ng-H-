using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Media : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Required]
        [Column(Order = 2)]
        // https://localhost:44327/assets/data/p35.jpg
        public string Link { get; set; }
        [Required]
        [Column(Order = 3)]
        // /assets/data/p35.jpg
        public string Path { get; set; }
        [Column(Order = 4)]
        public int MediaTypeId { get; set; }
        [Column(Order = 5)]
        public int OrderIndex { get; set; }
        public MediaType MediaType { get; set; }
        public List<Product_Media> Product_Media { get; set; }
    }
}
