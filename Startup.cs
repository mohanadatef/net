using KhadimiEssa.Hubs;
using DinkToPdf;
using DinkToPdf.Contracts;
using KhadimiEssa.Data;
using KhadimiEssa.Helper;
using KhadimiEssa.Implementation.App;
using KhadimiEssa.Implementation.Auth;
using KhadimiEssa.Implementation.Logic;
using KhadimiEssa.Interfaces.App;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.Interfaces.Logic;
using KhadimiEssa.Resources;
using KhadimiEssa.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhadimiEssa
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            //because you want a new version created every time you ask for it

            services.AddTransient<IChatServices, ChatServices>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IUploadImage, UploadImage>();
            services.AddTransient<IIntroSettingServices, IntroSettingServices>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAppClientService, AppClientService>();
            services.AddTransient<IAppDelegetService, AppDelegetService>();
            services.AddTransient<ILogicProviderService, LogicProviderService>();
            services.AddTransient<ILogicClientService, LogicClientService>();

            services.AddAutoMapper(typeof(Startup));

            #region localization

            services.AddLocalization(options => options.ResourcesPath = "Resources");


            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("ar"),
                    new CultureInfo("en") ,
                    new CultureInfo("ur") };

                options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            //.AddDataAnnotationsLocalization(); 
            .AddDataAnnotationsLocalization(o =>
            {
                o.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    return factory.Create(typeof(SharedResource));
                };
            });

            #endregion

            #region Identity Time Out
            services.AddDataProtection()
                                .SetApplicationName($"my-app-{Environment.EnvironmentName}")
                                .PersistKeysToFileSystem(new DirectoryInfo($@"{Environment.ContentRootPath}\keys"));

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(300);
            });
            #endregion

            services.AddControllersWithViews();
            #region identiy
            services.AddDefaultIdentity<ApplicationDbUser>(options =>
            {
                // Default Password settings.
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }).AddRoles<IdentityRole>().AddDefaultUI().AddEntityFrameworkStores<ApplicationDbContext>();

            #endregion
            #region  jwt
            //فى جزء فى ملف الjson
            services.AddAuthorization();

            services.AddAuthentication(

                ).AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Site"],
                        ValidIssuer = Configuration["Jwt:Site"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
                    };
                });
            #endregion
            #region Swagger
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigration>();
            services.AddTransient<IConfigureOptions<SwaggerUIOptions>, SwaggerUIConfiguration>();
            services.AddSwaggerGen();
            #endregion

            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            #region Swagger

            app.UseSwagger();

            app.UseSwaggerUI();

            #endregion
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            #region localization

            var supportedCultures = new[] {
                new CultureInfo("ar"),
                new CultureInfo("en"),
                new CultureInfo("ur") };
            supportedCultures[0].DateTimeFormat = supportedCultures[1].DateTimeFormat;
            supportedCultures[0].NumberFormat = supportedCultures[1].NumberFormat;

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(supportedCultures[0]),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    // Order is important, its in which order they will be evaluated
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                }
            };

            app.UseRequestLocalization(localizationOptions);

            #endregion


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<ChatHub>("/chatHub");

                endpoints.MapRazorPages();
            });
        }
    }
}
