using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OtakuShelter.Manga;

namespace OtakuShelter.Manga
{
	public class MangasController
	{
		private readonly MangaContext context;

		public MangasController(MangaContext context)
		{
			this.context = context;
		}
		
		public async Task Create(CreateMangaViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}
		
		public async Task<ReadMangaViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadMangaViewModel();
			
			await model.Load(context, filter.Offset, filter.Limit);
			
			return model;
		}

		public async Task<ReadByIdMangaViewModel> Read(int mangaId)
		{
			var model = new ReadByIdMangaViewModel();

			await model.Load(context, mangaId);

			return model;
		}

		public async Task Update(int mangaId, UpdateMangaViewModel model)
		{
			await model.Update(context, mangaId);
			
			await context.SaveChangesAsync();
		}

		public async Task Delete(DeleteMangaViewModel model)
		{
			await model.Delete(context);
			
			await context.SaveChangesAsync();
		}
	}
}