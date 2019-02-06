using System.Threading.Tasks;
using OtakuShelter.Manga;

namespace OtakuShelter.Manga
{
	public class ChaptersController
	{
		private readonly MangaContext context;

		public ChaptersController(MangaContext context)
		{
			this.context = context;
		}
		
		public async Task Create(int mangaId, CreateChapterViewModel model)
		{
			await model.Create(context, mangaId);

			await context.SaveChangesAsync();
		}

		public async Task<ReadChapterViewModel> Read(int mangaId, FilterViewModel filter)
		{
			var model = new ReadChapterViewModel();

			await model.Load(context, mangaId, filter.Offset, filter.Limit);

			return model;
		}
		
		public async Task<ReadByIdChapterViewModel> Read(int chapterId)
		{
			var model = new ReadByIdChapterViewModel();

			await model.Load(context, chapterId);

			return model;
		}

		public async Task Update(int chapterId, UpdateChapterViewModel model)
		{
			await model.Update(context, chapterId);
			
			await context.SaveChangesAsync();
		}

		public async Task Delete(DeleteChapterViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}