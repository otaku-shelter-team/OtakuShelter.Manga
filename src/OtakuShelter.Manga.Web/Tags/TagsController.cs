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

		public async Task Create(CreateTagViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task<ReadTagViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadTagViewModel();

			await model.Load(context, filter.Offset, filter.Limit);

			return model;
		}

		public async Task Update(int tagId, UpdateTagViewModel model)
		{
			await model.Update(context, tagId);

			await context.SaveChangesAsync();
		}

		public async Task Delete(DeleteTagViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}