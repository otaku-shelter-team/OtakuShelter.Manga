using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminDeleteByIdBookmarkViewModel
	{
		[DataMember(Name = "bookmarkId")]
		public int BookmarkId { get; set; }

		public async Task DeleteById(MangaContext context)
		{
			var bookmark = await context.Bookmarks.FirstAsync(b => b.Id == BookmarkId);

			context.Remove(bookmark);
		}
	}
}