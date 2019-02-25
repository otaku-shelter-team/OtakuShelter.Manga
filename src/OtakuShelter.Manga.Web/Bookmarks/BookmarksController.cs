using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace OtakuShelter.Manga
{
	public class BookmarksController : ControllerBase
	{
		private readonly MangaContext context;

		public BookmarksController(MangaContext context)
		{
			this.context = context;
		}

		public async ValueTask Create(CreateBookmarkRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Create(context, accountId);

			await context.SaveChangesAsync();
		}

		public async ValueTask<ReadBookmarkResponse> Read(FilterByMangaChapterAndPageIdRequest filter)
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var response = new ReadBookmarkResponse();

			await response.Read(context, accountId, filter.MangaId, filter.ChapterId, filter.PageId, filter.Offset, filter.Limit);

			return response;
		}

		public async ValueTask Delete(DeleteBookmarkRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Delete(context, accountId);

			await context.SaveChangesAsync();
		}

		public async ValueTask<ReadBookmarkResponse> AdminReadById(int accountId, FilterByMangaChapterAndPageIdRequest filter)
		{
			var response = new ReadBookmarkResponse();

			await response.Read(context, accountId, filter.MangaId, filter.ChapterId, filter.PageId, filter.Offset, filter.Limit);

			return response;
		}
		
		public async ValueTask AdminDeleteById(AdminDeleteByIdBookmarkRequest request)
		{
			await request.DeleteById(context);

			await context.SaveChangesAsync();
		}
	}
}