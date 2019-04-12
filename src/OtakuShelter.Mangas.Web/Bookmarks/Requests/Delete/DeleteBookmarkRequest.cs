using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class DeleteBookmarkRequest
	{
		[DataMember(Name = "bookmarkId")]
		public int BookmarkId { get; set; }

		public async ValueTask Delete(MangasContext context, int accountId)
		{
			var bookmark = await context.Bookmarks.FirstAsync(b => b.Id == BookmarkId && b.AccountId == accountId);

			context.Remove(bookmark);
		}
	}
}