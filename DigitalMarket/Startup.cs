using DigitalMarket.DAL.Contexts;
using DigitalMarket.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using DigitalMarket.Controllers;
using Microsoft.AspNetCore.Http;

namespace DigitalMarket
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DigitalMarket", Version = "v1" });
            });

            services.AddSession(o =>
            {
                
            });
            
            services.AddStackExchangeRedisCache(options => 
            {
                options.Configuration = Configuration.GetConnectionString("RedisCache");
            });

            services.AddDbContext<ProductsDbContext>(optionsAction => 
            {
                optionsAction.UseSqlServer(Configuration.GetConnectionString("ProductsString"));
            });

            services.AddSingleton<ILogger>(svc => svc.GetRequiredService<ILogger<ProductsController>>());            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductBasketService, ProductBasketService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DigitalMarket v1"));
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}