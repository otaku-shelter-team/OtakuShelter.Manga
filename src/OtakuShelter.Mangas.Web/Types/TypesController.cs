using System.Threading.Tasks;

namespace OtakuShelter.Mangas
{
	public class TypesController
	{
		private readonly MangasContext context;

		public TypesController(MangasContext context)
		{
			this.context = context;
		}
		
		public async ValueTask<ReadTypeResponse> Read(FilterRequest filter)
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