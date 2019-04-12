using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminDeleteByIdBookmarkRequest
	{
		[DataMember(Name = "bookmarkId")]
		public int BookmarkId { get; set; }

		public async ValueTask DeleteById(MangasContext context)
		{
			var bookmark = await context.Bookmarks.FirstAsync(b => b.Id == BookmarkId);

			context.Remove(bookmark);
		}
	}
}