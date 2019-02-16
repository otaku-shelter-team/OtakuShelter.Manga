using System.Threading.Tasks;

namespace OtakuShelter.Manga
{
	public class TagsController
	{
		private readonly MangaContext context;

		public TagsController(MangaContext context)
		{
			this.context = context;
		}

		public async Task<ReadTagViewModel> Read(FilterByMangaIdViewModel filter)
		{
			var model = new ReadTagViewModel();

			await model.Load(context, filter.MangaId, filter.Offset, filter.Limit);

			return model;
		}
		
		public async Task AdminCreate(AdminCreateTagViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task AdminUpdate(int tagId, AdminUpdateTagViewModel model)
		{
			await model.Update(context, tagId);

			await context.SaveChangesAsync();
		}

		public async Task AdminDelete(AdminDeleteTagViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}