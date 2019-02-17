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

		public async Task<ReadTranslatorViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadTranslatorViewModel();

			await model.Read(context, filter.Offset, filter.Limit);

			return model;
		}
		
		public async Task AdminCreate(AdminCreateTranslatorViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task AdminUpdate(int translatorId, AdminUpdateTranslatorViewModel model)
		{
			await model.Update(context, translatorId);

			await context.SaveChangesAsync();
		}

		public async Task AdminDelete(AdminDeleteTranslatorViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}