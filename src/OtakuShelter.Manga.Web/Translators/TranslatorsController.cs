using System.Threading.Tasks;

namespace OtakuShelter.Manga
{
	public class TranslatorsController
	{
		private readonly MangaContext context;

		public TranslatorsController(MangaContext context)
		{
			this.context = context;
		}

		public async Task Create(CreateTranslatorViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task<ReadTranslatorViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadTranslatorViewModel();

			await model.Load(context, filter.Offset, filter.Limit);

			return model;
		}

		public async Task Update(int translatorId, UpdateTranslatorViewModel model)
		{
			await model.Update(context, translatorId);

			await context.SaveChangesAsync();
		}

		public async Task Delete(DeleteTranslatorViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}