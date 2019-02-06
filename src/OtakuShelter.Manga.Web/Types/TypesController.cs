using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using OtakuShelter.Manga;

namespace OtakuShelter.Manga
{
	public class TypesController
	{
		private readonly MangaContext context;

		public TypesController(MangaContext context)
		{
			this.context = context;
		}

		public async Task Create(CreateTypeViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task<ReadTypeViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadTypeViewModel();

			await model.Load(context, filter.Offset, filter.Limit);

			return model;
		}

		public async Task Update(int typeId, UpdateTypeViewModel model)
		{
			await model.Update(context, typeId);

			await context.SaveChangesAsync();
		}

		public async Task Delete(DeleteTypeViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}