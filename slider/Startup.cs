using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Slider
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapCss();
                endpoints.MapJs();
                endpoints.MapImages();
                endpoints.MapHtml();
            });
        }
    }
}

