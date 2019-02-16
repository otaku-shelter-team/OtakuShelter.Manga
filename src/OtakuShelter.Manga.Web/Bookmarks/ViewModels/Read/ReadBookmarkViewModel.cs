using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadBookmarkViewModel
	{
		[DataMember(Name = "bookmarks")]
		public ICollection<ReadBookmarkItemViewModel> Bookmarks { get; set; }
		
		public async Task Read(MangaContext context, int accountId, int mangaId, int? chapterId, int? pageId, int offset, int limit)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

			var chapter = chapterId == null
				? null
				: await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			var page = pageId == null
				? null
				: await context.Pages.FirstAsync(p => p.Id == pageId);

			Bookmarks = await context.Bookmarks
				.AsNoTracking()
				.Where(b => b.AccountId == accountId)
				.Where(b => b.Manga == manga)
				.Where(b => b.Chapter == chapter)
				.Where(b => b.Page == page)
				.OrderByDescending(b => b.Created)
				.Skip(offset)
				.Take(limit)
				.Select(b => new ReadBookmarkItemViewModel(b))
				.ToListAsync();
		}
	}
}