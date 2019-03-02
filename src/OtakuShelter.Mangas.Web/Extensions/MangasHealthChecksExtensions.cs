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
	}
}