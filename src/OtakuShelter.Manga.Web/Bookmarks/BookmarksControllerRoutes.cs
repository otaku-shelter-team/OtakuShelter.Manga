using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class BookmarksControllerRoutes
	{
		public static IRoutingBuilder AddBookmarksController(this IRoutingBuilder builder)
		{
			builder.AddController<BookmarksController>(controller =>
			{
				controller.AddRoute(c => c.Read(From.Query<FilterByMangaChapterAndPageIdViewModel>()))
					.HttpGet()
					.Authorize();

				controller.AddRoute(c => c.Create(From.Body<CreateBookmarkViewModel>()))
					.HttpPost()
					.Authorize();

				controller.AddRoute("{bookmarkId}", c => c.Delete(From.Route<DeleteBookmarkViewModel>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("{accountId}",
						c => c.ReadById(From.Route<int>(), From.Query<FilterByMangaChapterAndPageIdViewModel>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("{accountId}/{bookmarkId}",
						c => c.DeleteById(From.Route<int>(), From.Route<DeleteBookmarkViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}