using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using MySql.Data.MySqlClient;

namespace Testing.Views.Shared
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration conf)
        {
            Configuration = conf;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDbConnection>((s) => 
            {
                IDbConnection conn=new MySqlConnection(Configuration.GetConnectionString("bestbuy"));
                conn.Open();
                return conn;
             });

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddControllersWithViews();

        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id}");
            });
        }            

    }
}
