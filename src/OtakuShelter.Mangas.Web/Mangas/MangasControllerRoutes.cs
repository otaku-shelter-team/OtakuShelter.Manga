using Phema.Routing;

namespace OtakuShelter.Mangas
{
	public static class MangasControllerRoutes
	{
		public static IRoutingBuilder AddMangasController(this IRoutingBuilder builder, MangasRoleConfiguration roles)
		{
			builder.AddController<MangasController>(controller =>
			{
				controller.AddRoute("mangas", c => c.Read(From.Query<FilterResponse>()))
					.HttpGet();

				controller.AddRoute("mangas/{mangaId}", c => c.ReadById(From.Route<int>()))
					.HttpGet();

				controller.AddRoute("admin/mangas", c => c.AdminCreate(From.Body<AdminCreateMangaRequest>()))
					.HttpPost()
					.Authorize(roles.Admin);
				
				controller.AddRoute("admin/mangas/{mangaId}",
						c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateMangaRequest>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/mangas/{mangaId}", c => c.AdminDelete(From.Route<AdminDeleteMangaRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}