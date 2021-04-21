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
    /// ���ǿ�������ʱ������࣬���Program.CreateHostBuilder������д��webBuilder.UseStartup(typeof(Program))ʹ��
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
        /// �Ҽ���Ŀ->����->����->�������������õ�ǰ����, ���ǿ�������ʱ���������������Configure�������÷���������ʱ����Configure������
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        //public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        //{

        //}

        /// <summary>
        /// �Ҽ���Ŀ->����->����->�������������õ�ǰ����, ������������ʱ���������������Configure�������÷���������ʱ����Configure������
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void ConfigureProduction(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

        /// <summary>
        /// �Ҽ���Ŀ->����->����->�������������õ�ǰ����, ������ʱ��ʾ����ʱ���������������Configure�������÷���������ʱ����Configure������
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void ConfigureStaging(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //���ǿ�������ʱ
            if (env.IsDevelopment())
            {
                //ʹ������м�����쳣ʱ��������Ϣ�����ҳ����
                app.UseDeveloperExceptionPage();
            }

            //�Զ���Ļ��������������Ҽ���Ŀ->����->����->��������������
            //if (env.IsEnvironment("OK"))
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //ʹ���м����������Ŀ��̬�ļ���
            //����images�����myself.pngͼƬ������·����https://localhost:5001/images/myself.png,
            //����https://localhost:5001/���������Ҽ���Ŀ->����->����->Web ����������->Ӧ�� URL(P)
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
