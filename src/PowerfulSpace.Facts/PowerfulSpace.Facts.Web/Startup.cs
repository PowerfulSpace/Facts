using Calabonga.AspNetCore.Controllers.Extensions;
using Calabonga.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Powerful.Facts.Contracts;
using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.Infrastructure.HostedServices;
using PowerfulSpace.Facts.Web.Infrastructure.Providers;
using PowerfulSpace.Facts.Web.Infrastructure.Services;
using PowerfulSpace.Facts.Web.Infrastructure.TagHelpers.PagedListTagHelper;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<IdentityOptions>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequiredLength = 6;
            });

            services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            //Подключени notification
            services.AddUnitOfWork<ApplicationDbContext>();

            //MapperRegistration.GetMapperConfiguration();
            services.AddAutoMapper(typeof(Startup));

            //Подключение медиатра
            services.AddCommandAndQueries(typeof(Startup).Assembly);

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<INotificationProvider, NotificationProvider>();
            services.AddTransient<IPagerTagHelperService, PagerTagHelperService>();
            services.AddTransient<IFactService, FactService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ITagSearchService, TagSearchService>();


            services.AddRouting(config =>
            {
                config.LowercaseQueryStrings = true;
                config.LowercaseUrls = true;
            });


            services.AddServerSideBlazor();

            services.AddResponseCaching();

            services.AddHostedService<NotificationHostedService>();



            services.AddControllersWithViews();
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Site/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "search",
                  pattern: "{controller=Facts" +
                  "}/{action=Index}/{tag:regex([a-zА-Я])}/{search:regex([a-zА-Я])}/{pageIndex:int?}");

                endpoints.MapControllerRoute(
                   name: "tag",
                   pattern: "{controller=Facts" +
                   "}/{action=Index}/{tag:regex([a-zА-Я])}/{pageIndex:int?}");

                endpoints.MapControllerRoute(
                  name: "index",
                  pattern: "{controller=Facts" +
                  "}/{action=Index}/{pageIndex:int?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Facts" +
                    "}/{action=Index}/{id?}");



                endpoints.MapRazorPages();

                endpoints.MapBlazorHub();

                endpoints.MapGet("/Identity/Account/Register", context => Task.Factory.StartNew(() =>
                context.Response.Redirect("/Identity/Account/Login?returnUrl=~%2F", true, true)));

            });
        }
    }
}
