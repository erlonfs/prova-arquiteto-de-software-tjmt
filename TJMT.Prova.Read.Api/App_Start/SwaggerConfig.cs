using Swashbuckle.Application;
using System;
using System.IO;
using System.Net.Http;
using System.Web.Http;

namespace TJMT.Prova.Read.Api
{
	public class SwaggerConfig
	{
		public static void Register()
		{
			var thisAssembly = typeof(SwaggerConfig).Assembly;

			GlobalConfiguration.Configuration
				.EnableSwagger(c =>
				{
					c.RootUrl(req => new Uri(req.RequestUri, req.GetRequestContext().VirtualPathRoot).ToString());

					c.UseFullTypeNameInSchemaIds();

					var binPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
					foreach (var file in Directory.GetFiles(binPath, "TJMT.Prova.*.xml"))
					{
						c.IncludeXmlComments(file);
					}

					c.SingleApiVersion("v1", "Api Read Model");

				})
				.EnableSwaggerUi(c =>
				{

				});
		}
	}
}
