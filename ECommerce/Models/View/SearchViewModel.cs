using ECommerce.Model.EFModel.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class SearchViewModel
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 9;
        public bool isDesc { get; set; } = true;
        public string orderBy { get; set; } = "CreateDate";
        public List<int> CategoryId { get; set; }
        public List<int> StatusId { get; set; } = null;

        public List<int> BrandNameId { get; set; }
        public bool IsDiscount { get; set; } = false;
        public string Sku { get; set; } = "";
        public List<int> MachineId { get; set; }
        public string Diameter { get; set; }
        public List<int> BandId { get; set; }
        public List<int> StrapId { get; set; }
        public List<int> ColorClockFaceId { get; set; }
        public List<int> MadeInId { get; set; }
        public List<int> StyleId { get; set; }
        public List<int> WaterproofId { get; set; }

        public List<BrandProduct> BrandProducts { get; set; }
        public List<Machine> Machines { get; set; }
        public List<Band> Bands { get; set; }
        public List<ColorClockFace> ColorClockFaces { get; set; }
        public List<MadeIn> MadeIns { get; set; }
        public List<Style> Styles { get; set; }
        public List<Strap> Straps { get; set; }
        public List<Waterproof> Waterproofs { get; set; }
        public List<Category> Category { get; set; }
        public List<Product> Products { get; set; }


    }
}
