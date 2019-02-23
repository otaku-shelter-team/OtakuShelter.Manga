using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class MangasControllerRoutes
	{
		public static IRoutingBuilder AddMangasController(this IRoutingBuilder builder, MangaRoleConfiguration roles)
		{
			builder.AddController<MangasController>(controller =>
			{
				controller.AddRoute("mangas", c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("mangas/{mangaId}", c => c.ReadById(From.Route<int>()))
					.HttpGet();

				controller.AddRoute("admin/mangas", c => c.AdminCreate(From.Body<AdminCreateMangaViewModel>()))
					.HttpPost()
					.Authorize(roles.Admin);
				
				controller.AddRoute("admin/mangas/{mangaId}",
						c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateMangaViewModel>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/mangas/{mangaId}", c => c.AdminDelete(From.Route<AdminDeleteMangaViewModel>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}