using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel
{
    public partial class Product
    {
       
        public int Id { get; set; }
        [Required]
        public int IdOrigin { get; set; }
        [Required]
        public int IdBrandProduct { get; set; }
        [Required]
        public int IdHuntingCase { get; set; }
        [Required]
        public int IdChatelaine { get; set; }
        [Required]
        public int IdColorClockFace { get; set; }
        [Required]
        public int IdMadeIn { get; set; }
        [Required]
        public int IdHem { get; set; }
        [Required]
        public int IdMachine { get; set; }
        [Required]
        public bool Sex { get; set; }
        public string Name { get; set; }
        public string Video { get; set; }
        public string Url { get; set; }
        [Required]
        public int? Price { get; set; }
        public int? PriceDiscount { get; set; }
        public string Code { get; set; }
        public int? Diameter { get; set; }
        public bool? Waterproof { get; set; }
        public string Guarantee { get; set; }
        public string Characteristics { get; set; }
        public string Function { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionFull { get; set; }
        public int? Status { get; set; }
    }
}
