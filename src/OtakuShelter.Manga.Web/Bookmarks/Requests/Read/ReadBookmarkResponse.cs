using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadBookmarkResponse
	{
		[DataMember(Name = "bookmarks")]
		public ICollection<ReadBookmarkItemResponse> Bookmarks { get; set; }
		
		public async ValueTask Read(MangaContext context, int accountId, int? mangaId, int? chapterId, int? pageId, int offset, int limit)
		{
			var bookmarks = context.Bookmarks
				.AsNoTracking()
				.Where(b => b.AccountId == accountId);

			if (mangaId != null)
			{
				var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

				bookmarks = bookmarks.Where(b => b.Manga == manga);
			}

			if (chapterId != null)
			{
				var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);
				
				bookmarks = bookmarks.Where(b => b.Chapter == chapter);
			}

			if (pageId != null)
			{
				var page = await context.Pages.FirstAsync(p => p.Id == pageId);
				
				bookmarks = bookmarks.Where(b => b.Page == page);
			}

			Bookmarks = await bookmarks
				.OrderByDescending(b => b.Created)
				.Skip(offset)
				.Take(limit)
				.Select(b => new ReadBookmarkItemResponse(b))
				.ToListAsync();
		}
	}
}