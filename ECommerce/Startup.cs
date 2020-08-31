using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECommerce.ConfigDI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using System.Globalization;
using System.Threading;
using ECommerce.Middlewares;
using Microsoft.AspNet.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using ECommerce.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ECommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Cài đặt session
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(10);
                options.Cookie.Name = OrderController.OrderSessionName;
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            #endregion
            services.AddControllersWithViews();
            services.AddSpaStaticFiles();
            #region NghiaTV config
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ECommerceContext")));

            //services.AddDefaultIdentity<ApplicationUser>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = false;
            //    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
            //})
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
                options.User.RequireUniqueEmail = false;
                options.User.RequireUniqueEmail = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))

                    };
                });


            #endregion
            services.RegisterServices();// DI
            services.AddMvc();
            services.AddOptions();

            #region Cài đặt đa ngữ hỗ trợ (Đa ngữ)
            var cultureLt = new CultureInfo("vi");
            var cultureEn = new CultureInfo("en");
            var supportedCultures = new[] { cultureEn, cultureLt };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            // Cài đặt ngôn ngữ mặc định của hệ thống
            CultureInfo ci = new CultureInfo("vi");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            //Add them to IServiceCollection(Thêm nó vào Service)
            services.AddLocalization(); // DI
            #endregion

            #region Viết lại URL của Account
            services.ConfigureApplicationCookie(options =>
            {

                ECommerce.Helpers.Common utils = new ECommerce.Helpers.Common();
                options.LoginPath = $"/tai-khoan/dang-nhap";
                options.AccessDeniedPath = "/tai-khoan/AccessDenied";
                //options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                //{
                //    OnRedirectToLogin = ctx =>
                //    {
                //        var requestPath = ctx.Request.Path;
                //        if (ctx.RedirectUri.ToLower().Contains("account/accessdenied"))
                //        {

                //            ctx.Response.Redirect("/" + utils.GetCurrentLang() + "/tai-khoan/AccessDenied");
                //        }
                //        if (ctx.RedirectUri.ToLower().Contains("account/login"))
                //        {
                //            ctx.Response.Redirect($"/{utils.GetCurrentLang()}/tai-khoan/dang-nhap");
                //        }
                //        return Task.CompletedTask;
                //    }
                //};

            });
            #endregion

            //services.AddIdentity();
            services.AddAuthorization();


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            #region session
            app.UseSession();
            #endregion
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            #region Cài đặt đa ngữ
            // Inject  Service của nó vào
            //app.UseRequestLocalization();
            app.UseMiddleware<LanguageMiddleware>();
            #endregion
            #region Authen
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion



            #region Cài đặt đường dẫn cho hệ thống
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{language:length(2)}/{controller}/{action}",
                    defaults: new
                    {
                        language = Thread.CurrentThread.CurrentCulture.ToString().ToLower(),
                        controller = "Home",
                        action = "Index"
                    }
                    );

                endpoints.MapAreaControllerRoute("areaRoute", "Admin",
                 pattern: "admin/{controller}/{action}",
                 defaults: new { controller = "Home", action = "Index" });
            });
            #endregion

        }


    }
}
