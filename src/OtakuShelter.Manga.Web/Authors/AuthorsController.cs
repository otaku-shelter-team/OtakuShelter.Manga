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
		
		public async ValueTask<ReadAuthorResponse> Read(FilterResponse filter)
		{
			var response = new ReadAuthorResponse();

			await response.Load(context, filter.Offset, filter.Limit);

			return response;
		}

		public async ValueTask<ReadAuthorsByIdResponse> ReadById(int mangaId, FilterResponse filter)
		{
			var response = new ReadAuthorsByIdResponse();

			await response.Read(context, mangaId, filter.Offset, filter.Limit);

			return response;
		}
		
		public async ValueTask AdminCreate(AdminCreateAuthorRequest request)
		{
			await request.Create(context);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminUpdate(int authorId, AdminUpdateAuthorRequest request)
		{
			await request.Update(context, authorId);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminDelete(AdminDeleteAuthorRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}