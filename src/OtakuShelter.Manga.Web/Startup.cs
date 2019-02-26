using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.SwaggerUI;

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
				.AddMvcServices(configuration.Roles)
				.AddAuthenticationServices(configuration)
				.AddSwaggerServices()
				.AddHelthServices(configuration.Database)
				.BuildServiceProvider();
		}
		
		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();

			app.UseHealthChecks("/health");
			
			app.UseAuthentication();
			
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("v1/swagger.json", "OtakuShelter Manga API v1");
				options.DocumentTitle = "OtakuShelter Manga API";
				options.DocExpansion(DocExpansion.None);
			});
			
			app.UseMvc();
		}
	}
}