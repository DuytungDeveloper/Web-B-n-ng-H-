using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Models.View;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Controllers
{

    public class SearchController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext db;

        public SearchController(ILogger<ProductController> logger, ApplicationDbContext _db, UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign)
        {
            db = _db;
            userManager = _usermana;
            signInManager = _sign;
            _logger = logger;
        }


        [Route("{language}/search-result")]
        [HttpGet()]
        //public IActionResult Index([FromQuery(Name = "page")] string page ="")
        public IActionResult Index(SearchViewModel searchData)
        {
            var lsBrandName = db.BrandProducts.Where(x => x != null).Include(x => x.Products).ToList();
            var lsMachine = db.Machines.Where(x => x != null).Include(x => x.Products).ToList();
            var lsBand = db.Bands.Where(x => x != null).Include(x => x.Products).ToList();
            var lsColorClockFace = db.ColorClockFaces.Where(x => x != null).Include(x => x.Products).ToList();
            var lsMadeIns = db.MadeIns.Where(x => x != null).Include(x => x.Products).ToList();
            var lsStyles = db.Styles.Where(x => x != null).Include(x => x.Products).ToList();
            var lsWaterproofs = db.Waterproofs.Where(x => x != null).Include(x => x.Products).ToList();
            searchData.BrandProducts = lsBrandName;
            searchData.Machines = lsMachine;
            searchData.Bands = lsBand;
            searchData.ColorClockFaces = lsColorClockFace;
            searchData.MadeIns = lsMadeIns;
            searchData.Styles = lsStyles;
            searchData.Straps = db.Straps.Where(x => x != null).Include(x => x.Products).ToList();
            searchData.Waterproofs = lsWaterproofs;
            searchData.Category = db.Category.Where(x => x != null).Include(x => x.Products).ToList();

            string sequenceMaxQuery = "select * from Products "
                                    + "where 1 = 1 ";
            string sequenceCount = "select * from Products "
                                    + "where 1 = 1 ";

            if (searchData.CategoryId != null && searchData.CategoryId.Count > 0)
            {
                sequenceMaxQuery += $"and CategoryId IN ({String.Join(",", searchData.CategoryId)}) ";
                sequenceCount += $"and CategoryId IN ({String.Join(",", searchData.CategoryId)}) ";
            }
            if (searchData.BrandNameId != null && searchData.BrandNameId.Count > 0)
            {
                sequenceMaxQuery += $"and BrandProductId IN ({String.Join(",", searchData.BrandNameId)}) ";
                sequenceCount += $"and BrandProductId IN ({String.Join(",", searchData.BrandNameId)}) ";
            }


            if (searchData.MachineId != null && searchData.MachineId.Count > 0)
            {
                sequenceMaxQuery += $"and MachineId IN ({String.Join(",", searchData.MachineId)}) ";
                sequenceCount += $"and MachineId IN ({String.Join(",", searchData.MachineId)}) ";
            }
            if (searchData.BandId != null && searchData.BandId.Count > 0)
            {
                sequenceMaxQuery += $"and BandId IN ({String.Join(",", searchData.BandId)}) ";
                sequenceCount += $"and BandId IN ({String.Join(",", searchData.BandId)}) ";
            }
            if (searchData.StrapId != null && searchData.StrapId.Count > 0)
            {
                sequenceMaxQuery += $"and StrapId IN ({String.Join(",", searchData.StrapId)}) ";
                sequenceCount += $"and StrapId IN ({String.Join(",", searchData.StrapId)}) ";
            }
            if (searchData.ColorClockFaceId != null && searchData.ColorClockFaceId.Count > 0)
            {
                sequenceMaxQuery += $"and ColorClockFaceId IN ({String.Join(",", searchData.ColorClockFaceId)}) ";
                sequenceCount += $"and ColorClockFaceId IN ({String.Join(",", searchData.ColorClockFaceId)}) ";
            }
            if (searchData.MadeInId != null && searchData.MadeInId.Count > 0)
            {
                sequenceMaxQuery += $"and MadeInId IN ({String.Join(",", searchData.MadeInId)}) ";
                sequenceCount += $"and MadeInId IN ({String.Join(",", searchData.MadeInId)}) ";
            }
            if (searchData.StyleId != null && searchData.StyleId.Count > 0)
            {
                sequenceMaxQuery += $"and StyleId IN ({String.Join(",", searchData.StyleId)}) ";
                sequenceCount += $"and StyleId IN ({String.Join(",", searchData.StyleId)}) ";
            }
            if (searchData.WaterproofId != null && searchData.WaterproofId.Count > 0)
            {
                sequenceMaxQuery += $"and WaterproofId IN ({String.Join(",", searchData.WaterproofId)}) ";
                sequenceCount += $"and WaterproofId IN ({String.Join(",", searchData.WaterproofId)}) ";
            }
            sequenceMaxQuery += $"and Price > {searchData.PriceFrom} ";
            sequenceMaxQuery += $"and Price < {searchData.PriceTo} ";
            if (string.IsNullOrWhiteSpace(searchData.SearchString) == false)
                sequenceMaxQuery += $"and CONCAT(Name,Id,Sku) LIKE N'%{searchData.SearchString.Replace("'", "%")}%' ";

            sequenceCount += $"and Price > {searchData.PriceFrom} ";
            sequenceCount += $"and Price < {searchData.PriceTo} ";
            if (string.IsNullOrWhiteSpace(searchData.SearchString) == false)
                sequenceCount += $"and CONCAT(Name,Id,Sku) LIKE N'%{searchData.SearchString.Replace("'", "%")}%' ";


            var order = searchData.isDesc ? "DESC" : "ASC";
            sequenceMaxQuery += $"ORDER BY {searchData.orderBy} {order} ";
            sequenceMaxQuery += $"OFFSET {searchData.Limit * searchData.Page} ROWS ";
            sequenceMaxQuery += $"FETCH NEXT {searchData.Limit} ROWS ONLY";

            var sequenceQueryResult = db.Products.FromSqlRaw(sequenceMaxQuery).Include(x => x.Reviews).Include(x => x.Product_Media).Include("Product_Media.Media").Include(i => i.Product_ProductStatus).ToList();
            var total = db.Products.FromSqlRaw(sequenceCount).Count();
            searchData.Products = sequenceQueryResult;
            searchData.Total = total;
            return View(searchData);
        }
    }
}