using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class BookmarksControllerRoutes
	{
		public static IRoutingBuilder AddBookmarksController(this IRoutingBuilder builder)
		{
			builder.AddController<BookmarksController>(controller =>
			{
				controller.AddRoute("bookmarks", c => c.Read(From.Query<FilterByMangaChapterAndPageIdViewModel>()))
					.HttpGet()
					.Authorize();

				controller.AddRoute("bookmarks", c => c.Create(From.Body<CreateBookmarkViewModel>()))
					.HttpPost()
					.Authorize();

				controller.AddRoute("bookmarks/{bookmarkId}", c => c.Delete(From.Route<DeleteBookmarkViewModel>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("admin/bookmarks/{accountId}",
						c => c.AdminReadById(From.Route<int>(), From.Query<FilterByMangaChapterAndPageIdViewModel>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("admin/bookmarks/{bookmarkId}",
						c => c.AdminDeleteById(From.Route<AdminDeleteByIdBookmarkViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}