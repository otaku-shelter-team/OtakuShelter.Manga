using System.Threading.Tasks;

namespace OtakuShelter.Manga
{
	public class ChaptersController
	{
		private readonly MangaContext context;

		public ChaptersController(MangaContext context)
		{
			this.context = context;
		}
		
		public async Task<ReadChapterViewModel> Read(int mangaId, FilterViewModel filter)
		{
			var model = new ReadChapterViewModel();

			await model.Load(context, mangaId, filter.Offset, filter.Limit);

			return model;
		}
		
		public async Task<ReadByIdChapterViewModel> ReadById(int chapterId)
		{
			var model = new ReadByIdChapterViewModel();

			await model.Load(context, chapterId);

			return model;
		}
		
		public async Task AdminCreate(int mangaId, AdminCreateChapterViewModel model)
		{
			await model.Create(context, mangaId);

			await context.SaveChangesAsync();
		}

		public async Task AdminUpdate(int chapterId, AdminUpdateChapterViewModel model)
		{
			await model.Update(context, chapterId);
			
			await context.SaveChangesAsync();
		}

		public async Task AdminDelete(AdminDeleteChapterViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}