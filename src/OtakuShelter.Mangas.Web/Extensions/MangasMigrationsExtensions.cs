using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Mangas
{
	public static class MangasMigrationsExtensions
	{
		public static void EnsureDatabaseMigrated(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider
					.GetRequiredService<MangasContext>()
					.Database
					.Migrate();
			}
		}
	}
}