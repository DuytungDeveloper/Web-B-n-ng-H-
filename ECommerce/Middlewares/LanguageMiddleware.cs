using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Middlewares
{
    public class LanguageMiddleware
    {
        /// <summary>
        /// Giống như Callback trong JS
        /// </summary>
        RequestDelegate _next;
        /// <summary>
        /// Inject option local
        /// </summary>
        private readonly IOptions<RequestLocalizationOptions> _localOptions;
        public LanguageMiddleware(RequestDelegate next, IOptions<RequestLocalizationOptions> localOptions)
        {
            _next = next;
            _localOptions = localOptions;
        }
        /// <summary>
        /// Hàm này sẽ kiểm tra dữ liệu vào và ra
        /// ở đây ta sẽ phân loại ngôn ngữ dựa vào URL
        /// </summary>
        /// <param name="context">Injection</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            var routeData = context.GetRouteData();
            var language = routeData.Values["language"] as string;

            var controller = routeData.Values["controller"] as string;
            var action = routeData.Values["action"] as string;
            var area = routeData.Values["area"] as string;
            var endpointFeature = context.Features[typeof(Microsoft.AspNetCore.Http.Features.IEndpointFeature)]
                                       as Microsoft.AspNetCore.Http.Features.IEndpointFeature;

            Microsoft.AspNetCore.Http.Endpoint endpoint = endpointFeature?.Endpoint;

            //Note: endpoint will be null, if there was no
            //route match found for the request by the endpoint route resolver middleware
            if (endpoint != null)
            {
                var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern
                                                                                           ?.RawText;

                Console.WriteLine("Name: " + endpoint.DisplayName);
                Console.WriteLine($"Route Pattern: {routePattern}");
                Console.WriteLine("Metadata Types: " + string.Join(", ", endpoint.Metadata));
            }

            language = (string.IsNullOrEmpty(language) ? "vi" : language).ToLower();
            var languageSupport = _localOptions.Value.SupportedCultures;
            bool isSupport = false;
            for (int i = 0; i < languageSupport.Count(); i++)
            {
                if (languageSupport[i].ToString().ToLower() == language.ToLower())
                {
                    isSupport = true;
                    break;
                }
            }
            language = isSupport ? language : "vi";
            var culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            await _next(context);
        }
    }
}
