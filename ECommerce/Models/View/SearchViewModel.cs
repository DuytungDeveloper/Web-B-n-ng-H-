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
        public string SearchString { get; set; }
        public int Page { get; set; } = 0;
        public int Limit { get; set; } = 9;
        public bool isDesc { get; set; } = true;
        public string orderBy { get; set; } = "CreateDate";
        public int Total { get; set; }
        public List<int> PageList
        {
            get
            {
                var rs = new List<int>();
                var currentPage = Page + 1; // trang hiện tại
                var total = Total;
                var maximumPageList = 5; // số trang hiện cho phép
                var limitList = int.Parse(Math.Ceiling((decimal)total / Limit).ToString()); // số trang cao nhất được hiện
                if (limitList < maximumPageList)
                {
                    for (int i = 0; i < limitList; i++)
                    {
                        rs.Add(i);
                    }
                }
                else
                {
                    var from = currentPage == 5 ? Page : currentPage;
                    var to = currentPage;
                    while (((decimal)from % 5) != (decimal)0)
                    {
                        from = from - 1;
                    }
                    while (((decimal)to % 5) != (decimal)0)
                    {
                        to = to + 1;
                        //Console.WriteLine("to " + to.ToString());
                    }
                    //Console.WriteLine("from " + from.ToString());
                    //Console.WriteLine("to " + to.ToString());
                    for (int i = from; i < to; i++)
                    {
                        rs.Add(i);
                    }
                }
                return rs;
            }
        }



        public List<int> CategoryId { get; set; }
        public List<int> StatusId { get; set; } = null;
        public float PriceFrom { get; set; } = 0;
        public float PriceTo { get; set; } = 500000000;

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
