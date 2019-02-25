using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadChapterResponse
	{
		[DataMember(Name = "chapters")]
		public ICollection<ReadChapterItemResponse> Chapters { get; private set; }

		public async ValueTask Load(MangaContext context, int mangaId, int offset, int limit)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

			Chapters = manga.Chapters
				.OrderBy(chapter => chapter.Order)
				.Skip(offset)
				.Take(limit)
				.Select(chapter => new ReadChapterItemResponse(chapter))
				.ToList();
		}
	}
}