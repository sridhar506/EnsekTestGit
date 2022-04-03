using EnsekEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnsekTechincalTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            CurrentEnv = environment;

        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnv { get; private set; }


        private string GetConnectionStringConfigSection()
        {
            if (CurrentEnv.IsDevelopment())
            {
                return "EnsekConnectionString";
            }
            //Production
            else
            {
                return "EnsekConnectionString";
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStr = Configuration.GetConnectionString(GetConnectionStringConfigSection());
            SqlConnectionStringBuilder sBuilder =
                new SqlConnectionStringBuilder(connectionStr);

            var fileName = Path.Combine(Environment.CurrentDirectory, @"AppData\EnsekDatabase.mdf");
            sBuilder.AttachDBFilename = fileName;


            services.AddDbContext<EnsekDBContext>(options => options.UseSqlServer(sBuilder.ConnectionString,
                x => x.UseNetTopologySuite()));
            RunMigrations();

            services.AddControllers();

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void RunMigrations()
        {
            var builder = new DbContextOptionsBuilder<EnsekDBContext>();
            var connectionStr = Configuration.GetConnectionString(GetConnectionStringConfigSection());

            SqlConnectionStringBuilder sBuilder =
                new SqlConnectionStringBuilder(connectionStr);

            var fileName = Path.Combine(Environment.CurrentDirectory, @"AppData\EnsekDatabase.mdf");
            sBuilder.AttachDBFilename = fileName;

            builder.UseSqlServer(sBuilder.ConnectionString,
                x => x.UseNetTopologySuite());
            var migrationContext = new EnsekDBContext(builder.Options);
            migrationContext.Database.Migrate();
            migrationContext.Dispose();
        }
    }
}
