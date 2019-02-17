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

		public async Task Create(CreateBookmarkViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);

			await model.Create(context, accountId);

			await context.SaveChangesAsync();
		}

		public async Task<ReadBookmarkViewModel> Read(FilterByMangaChapterAndPageIdViewModel filter)
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var model = new ReadBookmarkViewModel();

			await model.Read(context, accountId, filter.MangaId, filter.ChapterId, filter.PageId, filter.Offset, filter.Limit);

			return model;
		}

		public async Task Delete(DeleteBookmarkViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);

			await model.Delete(context, accountId);

			await context.SaveChangesAsync();
		}

		public async Task<ReadBookmarkViewModel> AdminReadById(int accountId, FilterByMangaChapterAndPageIdViewModel filter)
		{
			var model = new ReadBookmarkViewModel();

			await model.Read(context, accountId, filter.MangaId, filter.ChapterId, filter.PageId, filter.Offset, filter.Limit);

			return model;
		}
		
		public async Task AdminDeleteById(AdminDeleteByIdBookmarkViewModel model)
		{
			await model.DeleteById(context);

			await context.SaveChangesAsync();
		}
	}
}