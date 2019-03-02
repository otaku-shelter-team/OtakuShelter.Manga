using System.Threading.Tasks;


namespace OtakuShelter.Mangas
{
	public class PagesController
	{
		private readonly MangasContext context;

		public PagesController(MangasContext context)
		{
			this.context = context;
		}

		public async ValueTask<ReadPageResponse> Read(int chapterId, FilterResponse filter)
		{
			var response = new ReadPageResponse();

			await response.Load(context, chapterId, filter.Offset, filter.Limit);

			return response;
		}

		public async ValueTask<ReadByIdPageResponse> ReadById(int pageId)
		{
			var response = new ReadByIdPageResponse();

			await response.Load(context, pageId);

			return response;
		}
		
		public async ValueTask AdminCreate(int chapterId, AdminCreatePageRequest request)
		{
			await request.Create(context, chapterId);
			
			await context.SaveChangesAsync();
		}

		public async ValueTask AdminUpdate(int pageId, AdminUpdatePageRequest request)
		{
			await request.Update(context, pageId);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminDelete(AdminDeletePageRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}