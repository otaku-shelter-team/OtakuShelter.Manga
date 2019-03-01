using System;

using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
				.AddHelthServices(configuration.Database, configuration.RabbitMq)
				.AddRabbitMqServices(configuration.RabbitMq)
				.AddExceptionHandlingServices()
				.BuildServiceProvider();
		}
		
		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();

			app.UseHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
			
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