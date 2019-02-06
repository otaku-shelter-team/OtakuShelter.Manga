using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Manga
{
	public static class MangaDataExtensions
	{
		public static IServiceCollection AddDataServices(
			this IServiceCollection services,
			MangaDatabaseConfiguration database)
		{
			services.AddDbContext<MangaContext>(
				DesignTimeMangaContextFactory.CreateDbContextOptionsConfiguration(database));
			
			return services;
		}
	}
}