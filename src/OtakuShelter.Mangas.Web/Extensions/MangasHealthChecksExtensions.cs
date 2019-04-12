using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Mangas
{
	public static class MangasHealthChecksExtensions
	{
		public static IServiceCollection AddMangasHealthChecks(
			this IServiceCollection services,
			MangasDatabaseConfiguration database,
			MangasRabbitMqConfiguration rabbitMq)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString)
				.AddRabbitMQ(rabbitMq.ConnectionString);

			return services;
		}

		public static IApplicationBuilder UseMangasHealthchecks(this IApplicationBuilder app)
		{
			return app.UseHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
		}
	}
}