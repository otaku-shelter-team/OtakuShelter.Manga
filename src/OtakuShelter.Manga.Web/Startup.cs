using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
			app.EnsureDatabaseMigrated();
			
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "OtakuShelter API v1"));
			
			app.UseMvc();
		}
	}
}