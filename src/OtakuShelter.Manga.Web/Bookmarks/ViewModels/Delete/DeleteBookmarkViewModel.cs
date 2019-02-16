using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class DeleteBookmarkViewModel
	{
		[DataMember(Name = "bookmarkId")]
		public int BookmarkId { get; set; }

		public async Task Delete(MangaContext context, int accountId)
		{
			var bookmark = await context.Bookmarks.FirstAsync(b => b.Id == BookmarkId && b.AccountId == accountId);

			context.Remove(bookmark);
		}
	}
}