using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class Product
    {
        public int Id { get; set; }
        public int? IdOrigin { get; set; }
        public int? IdBrandProduct { get; set; }
        public int? IdHuntingCase { get; set; }
        public int? IdChatelaine { get; set; }
        public int? IdColorClockFace { get; set; }
        public int? IdMadeIn { get; set; }
        public int? IdHem { get; set; }
        public int? IdMachine { get; set; }
        public bool? Sex { get; set; }
        public string Name { get; set; }
        public string Video { get; set; }
        public string Url { get; set; }
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
