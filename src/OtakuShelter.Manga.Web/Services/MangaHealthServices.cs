using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Manga
{
	public static class MangaHealthServices
	{
		public static IServiceCollection AddHelthServices(
			this IServiceCollection services,
			MangaContextConfiguration database,
			MangaRabbitMqConfiguration rabbitMq)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString, tags: new[] {"PostgreSQL"})
				.AddRabbitMQ(rabbitMq.ConnectionString, tags: new[] {"RabbitMQ"});

			return services;
		}
	}
}