using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadPageViewModel
	{
		[DataMember(Name = "pages")]
		public ICollection<ReadPageItemViewModel> Pages { get; private set; }

		public async Task Load(MangaContext context, int chapterId, int offset, int limit)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			Pages = chapter.Pages
				.Skip(offset)
				.Take(limit)
				.Select(p => new ReadPageItemViewModel(p))
				.ToList();
		}
	}
}