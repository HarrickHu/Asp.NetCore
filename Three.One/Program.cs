using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Three.One
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((context, configBuilder) =>
                    {
                        //������Ĭ�ϵ������ļ�appsettings.json, ʹ��ָ���������ļ�nick.json
                        configBuilder.Sources.Clear();
                        configBuilder.AddJsonFile("nick.json");
                    })
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        //���Startup.cs�е�Startup��
                        webBuilder.UseStartup<Startup>();

                        //���Startup.cs�о���ʵ����ʹ�ã��Ҳ�������Startup��
                        //webBuilder.UseStartup(typeof(Program));
                    });
    }
}
