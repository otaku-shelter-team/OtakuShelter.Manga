using Phema.Routing;

namespace OtakuShelter.Mangas
{
	public static class ChaptersControllerRoutes
	{
		public static IRoutingBuilder AddChaptersController(this IRoutingBuilder builder, MangasRoleConfiguration roles)
		{
			builder.AddController<ChaptersController>(controller =>
			{
				controller.AddRoute("chapters/{mangaId}", c => c.Read(From.Route<int>(), From.Query<FilterRequest>()))
					.HttpGet();
				
//				TODO: chto eto
//				controller.AddRoute("chapters/{chapterId}", c => c.ReadById(From.Route<int>()))
//					.HttpGet();
				
				controller.AddRoute("admin/{mangaId}/chapters",
						c => c.AdminCreate(From.Route<int>(), From.Body<AdminCreateChapterRequest>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/chapters/{chapterId}",
						c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateChapterRequest>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/chapters/{chapterId}",
						c => c.AdminDelete(From.Route<AdminDeleteChapterRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});

			return builder;
		}
	}
}