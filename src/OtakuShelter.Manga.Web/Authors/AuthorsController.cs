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
		
		public async Task<ReadAuthorViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadAuthorViewModel();

			await model.Load(context, filter.Offset, filter.Limit);

			return model;
		}
		
		public async Task AdminCreate(AdminCreateAuthorViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task AdminUpdate(int authorId, AdminUpdateAuthorViewModel model)
		{
			await model.Update(context, authorId);

			await context.SaveChangesAsync();
		}

		public async Task AdminDelete(AdminDeleteAuthorViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}