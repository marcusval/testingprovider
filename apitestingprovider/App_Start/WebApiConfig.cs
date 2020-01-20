using System.Web.Http;

namespace apitestingprovider
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services f

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // The code below returns the data in Json format, it can still give back in xml when requested
            // This is better than the first line below since it still has the option for the xml if needed
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));


            // TAKE OUT THE COMMENT FOR THE LINE BELOW TO ONLY BE ABLE TO RETURN JSON DATA
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

        }
    }
}
