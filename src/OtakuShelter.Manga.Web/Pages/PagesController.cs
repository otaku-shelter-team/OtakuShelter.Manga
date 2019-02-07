using System.Threading.Tasks;
using OtakuShelter.Manga;

namespace OtakuShelter.Manga
{
	public class PagesController
	{
		private readonly MangaContext context;

		public PagesController(MangaContext context)
		{
			this.context = context;
		}

		public async Task Create(int chapterId, CreatePageViewModel model)
		{
			await model.Create(context, chapterId);
			
			await context.SaveChangesAsync();
		}

		public async Task<ReadPageViewModel> Read(int chapterId, FilterViewModel filter)
		{
			var model = new ReadPageViewModel();

			await model.Load(context, chapterId, filter.Offset, filter.Limit);

			return model;
		}

		public async Task<ReadByIdPageViewModel> ReadById(int pageId)
		{
			var model = new ReadByIdPageViewModel();

			await model.Load(context, pageId);

			return model;
		}

		public async Task Update(int pageId, UpdatePageViewModel model)
		{
			await model.Update(context, pageId);

			await context.SaveChangesAsync();
		}

		public async Task Delete(DeletePageViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}