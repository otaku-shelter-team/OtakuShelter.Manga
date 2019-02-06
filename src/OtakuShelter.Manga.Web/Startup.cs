using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Manga
{
	public class Startup : IStartup
	{
		private readonly MangaWebConfiguration configuration;

		public Startup(IOptions<MangaWebConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddDataServices(configuration.Database)
				.AddWebServices()
				.BuildServiceProvider();
		}
		
		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}
	}
}