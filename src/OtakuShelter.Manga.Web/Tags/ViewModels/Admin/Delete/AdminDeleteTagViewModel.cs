using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminDeleteTagViewModel
	{
		[DataMember(Name = "tagId")]
		public int TagId { get; set; }
		
		public async Task Delete(MangaContext context)
		{
			var tag = await context.Tags.FirstAsync(t => t.Id == TagId);

			context.Tags.Remove(tag);
		}
	}
}