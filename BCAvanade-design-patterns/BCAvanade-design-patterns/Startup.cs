using BCAvanade_design_patterns.Domain.Interfaces;
using BCAvanade_design_patterns.Infra.Facede;
using BCAvanade_design_patterns.Infra.Repository;
using BCAvanade_design_patterns.Infra.Repository.EF;
using BCAvanade_design_patterns.Infra.Singleton;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace BCAvanade_design_patterns
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BCAvanade Design Patterns", Version = "v1" });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "BCAvanade-design-patterns.xml");
                c.IncludeXmlComments(apiPath);
            });

            services.AddSingleton<SingletonContainer>();
            //services.AddSingleton<IVeiculoRepository, InMemoryRepository>();
            services.AddTransient<IVeiculoDetran, VeiculoDetranFacade>();

            services.AddTransient<IVeiculoRepository, FrotaRepository>();
            services.AddTransient<IVeiculoDetran, VeiculoDetranFacade>();

            IServiceCollection serviceCollection = services.AddDbContext<FrotaContext>(opt =>
                                               opt.UseInMemoryDatabase("Frota"));

            services.AddHttpClient();

            services.Configure<DetranOptions>(Configuration.GetSection("DetranOptions"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BCAvanade Design Patterns v1"));
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
