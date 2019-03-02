using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Mangas
{
	public static class MangasDatabaseExtensions
	{
		public static IServiceCollection AddMangasDatabase(
			this IServiceCollection services,
			MangasDatabaseConfiguration configuration)
		{
			services.AddDbContextPool<MangasContext>(options =>
				options.UseNpgsql(configuration.ConnectionString, builder =>
						builder.MigrationsHistoryTable(configuration.MigrationsTable))
					.ConfigureWarnings(builder => builder.Throw(RelationalEventId.QueryClientEvaluationWarning)));

			return services;
		}
	}
}