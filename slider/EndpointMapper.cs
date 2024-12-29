using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System.Text;
namespace Slider
{
    public static class EndpointMapper
    {
        /// <summary>
        /// Маппинг CSS-файлов
        /// </summary>
        public static void MapCss(this IEndpointRouteBuilder builder)
        {
            var cssFiles = new[] { "slider.css" };

            foreach (var fileName in cssFiles)
            {
                builder.MapGet($"/Static/CSS/{fileName}", async context =>
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "CSS", fileName);
                    var css = await File.ReadAllTextAsync(cssPath);
                    context.Response.ContentType = "text/css";
                    await context.Response.WriteAsync(css);
                });
            }
        }

        /// <summary>
        /// Маппинг JS-файлов
        /// </summary>
        public static void MapJs(this IEndpointRouteBuilder builder)
        {
            var jsFiles = new[] { "index.js", "slider.js" };

            foreach (var fileName in jsFiles)
            {
                builder.MapGet($"/Static/JS/{fileName}", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JS", fileName);
                    var js = await File.ReadAllTextAsync(jsPath);
                    context.Response.ContentType = "application/javascript";
                    await context.Response.WriteAsync(js);
                });
            }
        }

        /// <summary>
        /// Маппинг изображений
        /// </summary>
        public static void MapImages(this IEndpointRouteBuilder builder)
        {
            var imageFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Static", "Images"));

            foreach (var imagePath in imageFiles)
            {
                var fileName = Path.GetFileName(imagePath);
                builder.MapGet($"/Static/Images/{fileName}", async context =>
                {
                    var image = await File.ReadAllBytesAsync(imagePath);
                    context.Response.ContentType = "image/jpeg"; // Измените на image/png для PNG
                    await context.Response.Body.WriteAsync(image);
                });
            }
        }
        public static void MapHtml(this IEndpointRouteBuilder builder)
        {
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sidebar.html"));

            builder.MapGet("/", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);
                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/slider", async context =>
            {
                var sliderPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "slider.html");
                var sliderHtml = await File.ReadAllTextAsync(sliderPath);
                await context.Response.WriteAsync(sliderHtml);
            });
        }

    }
}