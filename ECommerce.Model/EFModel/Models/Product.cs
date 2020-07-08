using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model.EFModel.Models
{
    public partial class Product : BaseModel, IBaseModel
    {

        [Required]
        public int Id { get; set; }
       
        public int? IdOrigin { get; set; }
        public virtual Origin Origin { get; set; }
       
        public int? IdBrandProduct { get; set; }
        public virtual BrandProduct BrandProduct { get; set; }
      
        public int? IdHuntingCase { get; set; }
        public virtual HuntingCase HuntingCase { get; set; }
       
        public int? IdChatelaine { get; set; }
        public virtual Chatelaine Chatelaine { get; set; }
        
        public int? IdColorClockFace { get; set; }
        public virtual ColorClockFace ColorClockFace { get; set; }
      
        public int? IdMadeIn { get; set; }
        public virtual MadeIn MadeIn { get; set; }
       
        public int? IdHem { get; set; }
        public virtual Hem Hem { get; set; }
       
        public int? IdMachine { get; set; }
        public virtual Machine Machine { get; set; }
     
        public bool Sex { get; set; }
        [Required]
        public string Name { get; set; }
        public string Video { get; set; }
        public string Url { get; set; }
        [Required]
        public int Price { get; set; }
        public int PriceDiscount { get; set; }
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
