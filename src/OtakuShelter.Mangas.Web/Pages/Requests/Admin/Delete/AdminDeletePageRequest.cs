using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminDeletePageRequest
	{
		[DataMember(Name = "pageId")]
		public int PageId { get; set; }

		public async ValueTask Delete(MangasContext context)
		{
			var page = await context.Pages.FirstAsync(p => p.Id == PageId);

			context.Pages.Remove(page);
		}
	}
}