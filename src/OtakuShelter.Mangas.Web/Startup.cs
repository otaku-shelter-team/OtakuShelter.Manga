using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Mangas
{
	public class Startup : IStartup
	{
		private readonly MangasConfiguration configuration;

		public Startup(IOptions<MangasConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddMangasSwagger()
				.AddMangasExceptionHandling()
				.AddMangasMvc(configuration.Roles)
				.AddMangasDatabase(configuration.Database)
				.AddMangasRabbitMq(configuration.RabbitMq)
				.AddMangasAuthentication(configuration.Jwt)
				.AddMangasHealthChecks(configuration.Database, configuration.RabbitMq)
				.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();
			
			app.UseMangasHealthchecks();
			app.UseAuthentication();
			app.UseMangasSwagger();
			app.UseMvc();
		}
	}
}