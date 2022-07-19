using learn.core.domain;
using learn.core.Repoisitory;
using learn.core.Service;
using learn.infra.domain;
using learn.infra.Repoisitory;
using learn.infra.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API
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
            services.AddScoped<IDBContext, DbContext>();

            services.AddScoped<ICourse, api_courserepoisitory>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudent, api_studentrepoisitory>();


            services.AddScoped<ITask, api_taskrepoisitory>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddScoped<IEmp, api_emprepoisitory>();
            services.AddScoped<IEmpService, EmpService>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBook, api_bookrepoisitory>();

            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

           ).AddJwtBearer(y =>
           {
               y.RequireHttpsMetadata = false;
               y.SaveToken = true;
               y.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                   ValidateIssuer = false,
                   ValidateAudience = false,

               };


           });

            services.AddControllers();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
