using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Slider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting SliderApp...");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // ��������� ����� Startup ��� ������������ ����������
                    webBuilder.UseStartup<Startup>();
                });
    }
}

