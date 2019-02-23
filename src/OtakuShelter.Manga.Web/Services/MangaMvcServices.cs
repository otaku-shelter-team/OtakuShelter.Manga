using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class MangaMvcServices
	{
		public static IServiceCollection AddMvcServices(
			this IServiceCollection services,
			MangaRoleConfiguration roles)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization(options =>
					options.AddPolicy("admin", builder => builder.RequireRole(roles.Admin)))
				.AddApiExplorer()
				.AddPhemaRouting(routing =>
					routing.AddMangasController(roles)
						.AddChaptersController(roles)
						.AddPagesController(roles)
						.AddTypesController(roles)
						.AddTagsController(roles)
						.AddTranslatorsController(roles)
						.AddAuthorsController(roles)
						.AddBookmarksController(roles))
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			return services;
		}
	}
}