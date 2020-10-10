using System.Web.Http;
using WebActivatorEx;
using CoinAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CoinAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration.EnableSwagger(c => c.SingleApiVersion("Version 1", "Coin")).EnableSwaggerUi();
        }
    }
}