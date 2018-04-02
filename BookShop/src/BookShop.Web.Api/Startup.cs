using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BookShop.Domain.Repositories;
using BookShop.Application.Services;
using BookShop.Data.DatabaseContext;
using BookShop.Data.Repositories;

namespace BookShop.Web.Api
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
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddAzureAdB2CBearer(options => Configuration.Bind("AzureAdB2C", options));

            services.AddMvc();
            services.AddCors();
            DbContextOptions<BookShopDatabaseontext> option =
               new DbContextOptionsBuilder<BookShopDatabaseontext>()
               .UseInMemoryDatabase(databaseName: "BreadShop")
               .Options;

            services.AddSingleton(option).AddScoped<BookShopDatabaseontext>();

            services.AddScoped<IAccountDetailsRepository, AccountDetailsRepository>();
            services.AddScoped<IAccountDetailsApplicationService, AccountDetailsApplicationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
