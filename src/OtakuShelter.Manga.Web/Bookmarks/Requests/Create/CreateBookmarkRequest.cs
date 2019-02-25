using System;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class CreateBookmarkRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		[DataMember(Name = "mangaId")]
		public int MangaId { get; set; }
		
		[DataMember(Name = "chapterId")]
		public int? ChapterId { get; set; }
		
		[DataMember(Name = "pageId")]
		public int? PageId { get; set; }

		public async ValueTask Create(MangaContext context, int accountId)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == MangaId);

			var chapter = ChapterId == null
				? null
				: await context.Chapters.FirstAsync(ch => ch.Id == ChapterId);
			
			var page = PageId == null
				? null
				: await context.Pages.FirstAsync(p => p.Id == PageId);

			var bookmark = new Bookmark
			{
				Name = Name,
				AccountId = accountId,
				Created = DateTime.UtcNow,
				Manga = manga,
				Chapter = chapter,
				Page = page
			};

			await context.Bookmarks.AddAsync(bookmark);
		}
	}
}