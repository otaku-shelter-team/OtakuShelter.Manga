using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace OtakuShelter.Mangas
{
	public class MangasController
	{
		private readonly MangasContext context;

		public MangasController(MangasContext context)
		{
			this.context = context;
		}
	
		public async ValueTask<ReadMangaResponse> Read(FilterResponse filter)
		{
			var response = new ReadMangaResponse();
			
			await response.Load(context, filter.Offset, filter.Limit);
			
			return response;
		}

		public async ValueTask<ReadByIdMangaResponse> ReadById(int mangaId)
		{
			var response = new ReadByIdMangaResponse();

			await response.ReadById(context, mangaId);

			return response;
		}
			
		public async ValueTask AdminCreate(AdminCreateMangaRequest request)
		{
			await request.Create(context);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminUpdate(int mangaId, AdminUpdateMangaRequest request)
		{
			await request.Update(context, mangaId);
			
			await context.SaveChangesAsync();
		}

		public async ValueTask AdminDelete(AdminDeleteMangaRequest request)
		{
			await request.Delete(context);
			
			await context.SaveChangesAsync();
		}
	}
}