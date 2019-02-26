using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Manga
{
	public static class MangaHealthServices
	{
		public static IServiceCollection AddHelthServices(
			this IServiceCollection services,
			MangaContextConfiguration database)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString);
			
			return services;
		}
	}
}