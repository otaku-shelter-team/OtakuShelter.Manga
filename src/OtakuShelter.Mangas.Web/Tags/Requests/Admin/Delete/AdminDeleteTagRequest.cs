using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminDeleteTagRequest
	{
		[DataMember(Name = "tagId")]
		public int TagId { get; set; }

		public async ValueTask Delete(MangasContext context)
		{
			var tag = await context.Tags.FirstAsync(t => t.Id == TagId);

			context.Tags.Remove(tag);
		}
	}
}