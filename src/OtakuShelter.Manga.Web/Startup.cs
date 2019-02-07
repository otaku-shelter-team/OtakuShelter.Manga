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
				.AddWebServices(configuration)
				.BuildServiceProvider();
		}
		
		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();

			app.UseAuthentication();
			
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "OtakuShelter Manga API v1"));
			
			app.UseMvc();
		}
	}
}