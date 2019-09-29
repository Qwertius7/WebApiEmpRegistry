using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApiEmpRegistry.exceptionHandlers;

namespace WebApiEmpRegistry
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Services.Replace(typeof(IExceptionHandler), new CommonExceptionHandler());

            config.Filters.Add(new InternalServerErrorFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
