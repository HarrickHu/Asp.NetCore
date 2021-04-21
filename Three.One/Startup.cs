using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Three.One.Services;

namespace Three.One
{
    /// <summary>
    /// 当是开发环境时走这个类，配合Program.CreateHostBuilder方法的写法webBuilder.UseStartup(typeof(Program))使用
    /// </summary>
    public class StartupDevelopment
    {

    }
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            //var three = _configuration["Three.One:BoldDepartmentEmployeeCountThreshold"];
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton<IClock, ChinaClock>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.Configure<ThreeOptions>(_configuration.GetSection(key: "Three"));
        }

        /// <summary>
        /// 右键项目->属性->调试->环境变量下配置当前环境, 当是开发环境时走这个方法，不走Configure方法，该方法不存在时才走Configure方法。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        //public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        //{

        //}

        /// <summary>
        /// 右键项目->属性->调试->环境变量下配置当前环境, 当是生产环境时走这个方法，不走Configure方法，该方法不存在时才走Configure方法。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void ConfigureProduction(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

        /// <summary>
        /// 右键项目->属性->调试->环境变量下配置当前环境, 当是临时演示环境时走这个方法，不走Configure方法，该方法不存在时才走Configure方法。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void ConfigureStaging(IApplicationBuilder app, IWebHostEnvironment env)
        {

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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Department}/{action=Index}/{id?}"
                );
            });
        }
    }
}
