using System.Threading.Tasks;

namespace OtakuShelter.Mangas
{
	public class TagsController
	{
		private readonly MangasContext context;

		public TagsController(MangasContext context)
		{
			this.context = context;
		}

		public async ValueTask<ReadTagResponse> Read(FilterRequest filter)
		{
			var response = new ReadTagResponse();

			await response.Load(context, filter.Offset, filter.Limit);

			return response;
		}
		
		public async ValueTask<ReadTagsByIdResponse> ReadById(int mangaId, FilterRequest filter)
		{
			var response = new ReadTagsByIdResponse();

			await response.Read(context, mangaId, filter.Offset, filter.Limit);

			return response;
		}
		
		public async ValueTask AdminCreate(AdminCreateTagRequest request)
		{
			await request.Create(context);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminUpdate(int tagId, AdminUpdateTagRequest request)
		{
			await request.Update(context, tagId);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminDelete(AdminDeleteTagRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}