using EasyMemoryCache;
using Integration.Classes;
using Integration.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Classes;
using Services.Interfaces;
using System;

namespace ApiTest
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
            var partnerUrl = Configuration.GetSection("PartnerUrl").Value;
            services.AddHttpClient<IUserClient, UserClient>(c =>
            {
                c.BaseAddress = new Uri(partnerUrl);
            });
            services.AddHttpClient<IPhotosClient, PhotoClient>(c =>
            {
                c.BaseAddress = new Uri(partnerUrl);
            });

            services.AddHttpClient<IAlbumsClient, AlbumsClient>(c =>
            {
                c.BaseAddress = new Uri(partnerUrl);
            });

            services.AddSingleton<IUserServices, UserService>();
            services.AddSingleton<IPhotosService, PhotosService>();
            services.AddSingleton<IAlbumsService, AlbumsService>();
            services.AddSingleton<ICaching, Caching>();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiTest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiTest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}