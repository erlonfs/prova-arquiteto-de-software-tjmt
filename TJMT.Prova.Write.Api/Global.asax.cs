using System.Web.Http;

namespace TJMT.Prova.Write.Api
{
	public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
