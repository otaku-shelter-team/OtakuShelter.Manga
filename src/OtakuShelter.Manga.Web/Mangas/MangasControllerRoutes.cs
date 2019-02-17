using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class MangasControllerRoutes
	{
		public static IRoutingBuilder AddMangasController(this IRoutingBuilder builder)
		{
			builder.AddController<MangasController>(controller =>
			{
				controller.AddRoute("mangas", c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("mangas/{mangaId}", c => c.ReadById(From.Route<int>()))
					.HttpGet();

				controller.AddRoute("mangas/{mangaId}/authors",
						c => c.ReadAuthorsById(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();
				
				controller.AddRoute("mangas/{mangaId}/tags",
						c => c.ReadTagsById(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();
				
				controller.AddRoute("mangas/{mangaId}/translators",
						c => c.ReadTranslatorsById(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("admin/mangas", c => c.AdminCreate(From.Body<AdminCreateMangaViewModel>()))
					.HttpPost()
					.Authorize("admin");
				
				controller.AddRoute("admin/mangas/{mangaId}",
						c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateMangaViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("admin/mangas/{mangaId}", c => c.AdminDelete(From.Route<AdminDeleteMangaViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}