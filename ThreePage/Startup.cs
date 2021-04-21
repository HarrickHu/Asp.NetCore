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
                endpoints.MapRazorPages();
            });
        }
    }
}
