using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Manga
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services, IOptions<OtakuShelterMangaConfiguration> options)
		{
			var configuration = options.Value;

			services.AddDataModule(configuration.DataConfiguration);
		}

		public void Configure(IApplicationBuilder app)
		{
			app.Run(async context => await context.Response.WriteAsync("Hello World!"));
		}
	}
}