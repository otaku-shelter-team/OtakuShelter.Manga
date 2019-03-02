using System.Threading.Tasks;

namespace OtakuShelter.Mangas
{
	public class ChaptersController
	{
		private readonly MangasContext context;

		public ChaptersController(MangasContext context)
		{
			this.context = context;
		}
		
		public async ValueTask<ReadChapterResponse> Read(int mangaId, FilterResponse filter)
		{
			var response = new ReadChapterResponse();

			await response.Load(context, mangaId, filter.Offset, filter.Limit);

			return response;
		}
		
		public async ValueTask<ReadByIdChapterResponse> ReadById(int chapterId)
		{
			var response = new ReadByIdChapterResponse();

			await response.Load(context, chapterId);

			return response;
		}
		
		public async ValueTask AdminCreate(int mangaId, AdminCreateChapterRequest request)
		{
			await request.Create(context, mangaId);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminUpdate(int chapterId, AdminUpdateChapterRequest request)
		{
			await request.Update(context, chapterId);
			
			await context.SaveChangesAsync();
		}

		public async ValueTask AdminDelete(AdminDeleteChapterRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}