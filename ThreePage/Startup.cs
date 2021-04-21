using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.One;
using Three.One.Services;

namespace ThreePage
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            //var three = _configuration["Three.One:BoldDepartmentEmployeeCountThreshold"];
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddSingleton<IClock, ChinaClock>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.Configure<ThreeOptions>(_configuration.GetSection(key: "Three"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //当是开发环境时
            if (env.IsDevelopment())
            {
                //使用这个中间件：异常时将错误信息输出在页面上
                app.UseDeveloperExceptionPage();
            }

            //自定义的环境变量名，在右键项目->属性->调试->环境变量下配置
            //if (env.IsEnvironment("OK"))
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //使用中间件：访问项目静态文件，
            //比如images下面的myself.png图片，访问路径是https://localhost:5001/images/myself.png,
            //其中https://localhost:5001/是配置在右键项目->属性->调试->Web 服务器设置->应用 URL(P)
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapRazorPages();
            });
        }
    }
}
