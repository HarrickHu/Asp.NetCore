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
                        //不适用默认的配置文件appsettings.json, 使用指定的配置文件nick.json
                        configBuilder.Sources.Clear();
                        configBuilder.AddJsonFile("nick.json");
                    })
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        //配合Startup.cs中的Startup类
                        webBuilder.UseStartup<Startup>();

                        //配合Startup.cs中具体实现类使用，找不到才走Startup类
                        //webBuilder.UseStartup(typeof(Program));
                    });
    }
}
