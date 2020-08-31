using ECommerce.Middlewares;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Helpers
{
    public class Common
    {
        public string GetCurrentLang()
        {
            return string.IsNullOrEmpty(Thread.CurrentThread.CurrentCulture.ToString().ToLower()) ? "vi" : Thread.CurrentThread.CurrentCulture.ToString().ToLower();
        }
    }
}
