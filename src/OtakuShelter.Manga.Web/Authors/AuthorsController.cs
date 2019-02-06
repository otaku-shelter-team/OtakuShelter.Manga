using System.Threading.Tasks;

namespace OtakuShelter.Manga
{
	public class AuthorsController
	{
		private readonly MangaContext context;

		public AuthorsController(MangaContext context)
		{
			this.context = context;
		}

		public async Task Create(CreateAuthorViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task<ReadAuthorViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadAuthorViewModel();

			await model.Load(context, filter.Offset, filter.Limit);

			return model;
		}

		public async Task Update(int authorId, UpdateAuthorViewModel model)
		{
			await model.Update(context, authorId);

			await context.SaveChangesAsync();
		}

		public async Task Delete(DeleteAuthorViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}