using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Common.FormatData;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Controllers
{
    [ApiController]
    public class APIController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext db;
        public APIController(ILogger<ProductController> logger, ApplicationDbContext _db, UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign)
        {
            db = _db;
            userManager = _usermana;
            signInManager = _sign;
            _logger = logger;
        }
        #region Manager Ward
        [Route("api/ward/all")]
        public async Task<IActionResult> GetAllWard()
        {
            try
            {
                List<Ward> rs = db.Wards.ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }
        [Route("api/ward/district")]
        // 
        public async Task<IActionResult> GetDistrictOfWard(int id)
        {
            try
            {
                List<District> rs = db.Districts.Where(x => x.Wards.Where(y => y.Id == id).Count() > 0).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }


        #endregion

        #region Manager District
        [Route("api/district/all")]
        public async Task<IActionResult> GetAllDistrict()
        {
            try
            {
                List<District> rs = db.Districts.ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }
        [Route("api/district/city")]
        // 
        public async Task<IActionResult> GetCityOfDistrict(int id)
        {
            try
            {
                List<City> rs = db.Citys.Where(x => x.Districts.Where(y => y.Id == id).Count() > 0).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }

        [Route("api/district/ward")]
        // 
        public async Task<IActionResult> GetWardOfDistrict(int id)
        {
            try
            {
                List<Ward> rs = db.Wards.Where(x => x.District.Id == id).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }

        #endregion

        #region Manager City
        [Route("api/city/all")]
        public async Task<IActionResult> GetAllCity()
        {
            try
            {
                List<City> rs = db.Citys.ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }
        [Route("api/city/district")]
        public async Task<IActionResult> GetDistrictOfCity(int id)
        {
            try
            {
                List<District> rs = db.Districts.Where(x => x.City.Id == id).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }
        #endregion

    }
}