using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminDeleteTypeRequest
	{
		[DataMember(Name = "typeId")]
		public int TypeId { get; set; }

		public async ValueTask Delete(MangasContext context)
		{
			var type = await context.Types.FirstAsync(t => t.Id == TypeId);

			context.Types.Remove(type);
		}
	}
}