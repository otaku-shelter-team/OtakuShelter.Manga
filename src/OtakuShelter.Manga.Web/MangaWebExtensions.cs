using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Phema.Routing;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace OtakuShelter.Manga
{
	public static class MangaWebExtensions
	{
		public static IServiceCollection AddWebServices(
			this IServiceCollection services)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddApiExplorer()
				.AddPhemaRouting(configuration => 
					configuration.AddMangasController()
						.AddChaptersController()
						.AddPagesController()
						.AddTypesController()
						.AddTagsController()
						.AddTranslatorsController()
						.AddAuthorsController());

			services.AddSwaggerGen(options => 
				options.SwaggerDoc("v1", new Info { Title = "OtakuShelter API", Version = "v1" }));
			
			return services;
		}

		public static void EnsureDatabaseMigrated(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider
					.GetRequiredService<MangaContext>()
					.Database
					.Migrate();
			}
		}
	}
}