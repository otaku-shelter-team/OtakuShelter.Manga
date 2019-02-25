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
		
		public async ValueTask<ReadTypeResponse> Read(FilterResponse filter)
		{
			var response = new ReadTypeResponse();

			await response.Load(context, filter.Offset, filter.Limit);

			return response;
		}

		public async ValueTask AdminCreate(AdminCreateTypeRequest request)
		{
			await request.Create(context);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminUpdate(int typeId, AdminUpdateTypeRequest request)
		{
			await request.Update(context, typeId);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminDelete(AdminDeleteTypeRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}