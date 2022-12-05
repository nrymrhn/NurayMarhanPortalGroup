using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NurayMarhanPortalGroup.Business.Abstract;
using NurayMarhanPortalGroup.Business.Concrete;
using NurayMarhanPortalGroup.Repository.Abstract;
using NurayMarhanPortalGroup.Repository.Concrete;
using NurayMarhanPortalGroup.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NurayMarhanPortalGroup.API", Version = "v1" });
            });

            services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-KER4I6U; Database=PortalGroupDb; Uid=sa; Pwd=123;");
            });
         
            services.AddTransient(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NurayMarhanPortalGroup.API v1"));
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
