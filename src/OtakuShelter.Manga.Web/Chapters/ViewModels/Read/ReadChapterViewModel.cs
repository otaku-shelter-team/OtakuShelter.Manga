using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadChapterViewModel
	{
		[DataMember(Name = "chapters")]
		public ICollection<ReadChapterItemViewModel> Chapters { get; private set; }

		public async Task Load(MangaContext context, int mangaId, int offset, int limit)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

			Chapters = manga.Chapters
				.Skip(offset)
				.Take(limit)
				.Select(chapter => new ReadChapterItemViewModel(chapter))
				.ToList();
		}
	}
}