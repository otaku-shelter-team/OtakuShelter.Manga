using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class ChaptersControllerRoutes
	{
		public static IRoutingBuilder AddChaptersController(this IRoutingBuilder builder)
		{
			builder.AddController<ChaptersController>(controller =>
			{
				controller.AddRoute("{mangaId}/chapters", c => c.Read(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("chapters/{chapterId}", c => c.ReadById(From.Route<int>()))
					.HttpGet();
				
				controller.AddRoute("admin/{mangaId}/chapters",
						c => c.AdminCreate(From.Route<int>(), From.Body<AdminCreateChapterViewModel>()))
					.HttpPost()
					.Authorize("admin");

				controller.AddRoute("admin/chapters/{chapterId}",
						c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateChapterViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("admin/chapters/{chapterId}",
						c => c.AdminDelete(From.Route<AdminDeleteChapterViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}