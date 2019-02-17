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
	
		public async Task<ReadMangaViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadMangaViewModel();
			
			await model.Load(context, filter.Offset, filter.Limit);
			
			return model;
		}

		public async Task<ReadByIdMangaViewModel> ReadById(int mangaId)
		{
			var model = new ReadByIdMangaViewModel();

			await model.ReadById(context, mangaId);

			return model;
		}

		public async Task<ReadMangaAuthorsByIdViewModel> ReadAuthorsById(int mangaId, FilterViewModel filter)
		{
			var model = new ReadMangaAuthorsByIdViewModel();

			await model.Read(context, mangaId, filter.Offset, filter.Limit);

			return model;
		}
		
		public async Task<ReadMangaTagsByIdViewModel> ReadTagsById(int mangaId, FilterViewModel filter)
		{
			var model = new ReadMangaTagsByIdViewModel();

			await model.Read(context, mangaId, filter.Offset, filter.Limit);

			return model;
		}
		
		public async Task<ReadMangaTranslatorsByIdViewModel> ReadTranslatorsById(int mangaId, FilterViewModel filter)
		{
			var model = new ReadMangaTranslatorsByIdViewModel();

			await model.Read(context, mangaId, filter.Offset, filter.Limit);

			return model;
		}
		
			
		public async Task AdminCreate(AdminCreateMangaViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task AdminUpdate(int mangaId, AdminUpdateMangaViewModel model)
		{
			await model.Update(context, mangaId);
			
			await context.SaveChangesAsync();
		}

		public async Task AdminDelete(AdminDeleteMangaViewModel model)
		{
			await model.Delete(context);
			
			await context.SaveChangesAsync();
		}
	}
}