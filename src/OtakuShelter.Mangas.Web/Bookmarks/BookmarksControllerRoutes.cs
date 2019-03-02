using Phema.Routing;

namespace OtakuShelter.Mangas
{
	public static class BookmarksControllerRoutes
	{
		public static IRoutingBuilder AddBookmarksController(this IRoutingBuilder builder, MangasRoleConfiguration roles)
		{
			builder.AddController<BookmarksController>(controller =>
			{
				controller.AddRoute("bookmarks", c => c.Read(From.Query<FilterByMangaChapterAndPageIdRequest>()))
					.HttpGet()
					.Authorize();

				controller.AddRoute("bookmarks", c => c.Create(From.Body<CreateBookmarkRequest>()))
					.HttpPost()
					.Authorize();

				controller.AddRoute("bookmarks/{bookmarkId}", c => c.Delete(From.Route<DeleteBookmarkRequest>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("admin/bookmarks/{accountId}",
						c => c.AdminReadById(From.Route<int>(), From.Query<FilterByMangaChapterAndPageIdRequest>()))
					.HttpGet()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/bookmarks/{bookmarkId}",
						c => c.AdminDeleteById(From.Route<AdminDeleteByIdBookmarkRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}