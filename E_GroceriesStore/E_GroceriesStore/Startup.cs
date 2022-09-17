using E_GroceriesStore.DataAccess;
using E_GroceriesStore.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceriesStore
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
            services.AddDbContext<E_GroceryStoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddControllers();
            services.AddScoped<IUser, User>(); // dependency injection
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                                 AddCookie(options =>
                                 {
                                     options.ExpireTimeSpan = new TimeSpan(0, 10, 0);
                                     options.Events.OnRedirectToLogin = (context) =>
                                     {
                                         context.Response.StatusCode = 401;
                                         return Task.CompletedTask;
                                     };

                                 });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Api",
                    Version = "v1"
                });
            });

            // here we are using angular and sending rqst to .net core(i.e, sending rqst to another domain) so CORS allow cross origin resourse sharing.
            services.AddCors(options => 
            {
                options.AddPolicy(name:"AllowCrossOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowCrossOrigin");
            app.UseAuthentication(); // Authentication---confirming identity of someone

            app.UseAuthorization(); // Authorization---granting access to the system  

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
