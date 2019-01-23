using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Manga
{
	public static class OtakuShelterMangaDataModule
	{
		public static IServiceCollection AddDataModule(
			this IServiceCollection services,
			OtakuShelterDataConfiguration configuration)
		{
			services.AddDbContext<OtakuShelterContext>(
				options => options
					.UseLazyLoadingProxies()
					.UseNpgsql(configuration.DatabaseConnectionString, builder => builder
						.MigrationsAssembly(configuration.MigrationsAssembly)
						.MigrationsHistoryTable(configuration.MigrationsTable, configuration.MigrationsSchema)));

			return services;
		}
	}
}