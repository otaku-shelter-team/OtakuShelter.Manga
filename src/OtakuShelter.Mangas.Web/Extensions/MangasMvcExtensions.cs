using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Phema.Routing;

namespace OtakuShelter.Mangas
{
	public static class MangasMvcExtensions
	{
		public static IServiceCollection AddMangasMvc(
			this IServiceCollection services,
			MangasRoleConfiguration roles)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization(options =>
					options.AddPolicy("admin", builder => builder.RequireRole(roles.Admin)))
				.AddApiExplorer()
				.AddPhemaRouting(routing => routing.AddMangasController(roles)
					.AddChaptersController(roles)
					.AddPagesController(roles)
					.AddTypesController(roles)
					.AddTagsController(roles)
					.AddTranslatorsController(roles)
					.AddAuthorsController(roles)
					.AddBookmarksController(roles)
					.AddVersionController())
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			return services;
		}
	}
}