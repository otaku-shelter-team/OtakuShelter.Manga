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

		public async ValueTask<ReadTranslatorResponse> Read(FilterResponse filter)
		{
			var response = new ReadTranslatorResponse();

			await response.Read(context, filter.Offset, filter.Limit);

			return response;
		}
		
		
		public async ValueTask<ReadTranslatorsByIdResponse> ReadById(int mangaId, FilterResponse filter)
		{
			var response = new ReadTranslatorsByIdResponse();

			await response.Read(context, mangaId, filter.Offset, filter.Limit);

			return response;
		}
		
		public async ValueTask AdminCreate(AdminCreateTranslatorRequest request)
		{
			await request.Create(context);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminUpdate(int translatorId, AdminUpdateTranslatorRequest request)
		{
			await request.Update(context, translatorId);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminDelete(AdminDeleteTranslatorRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}