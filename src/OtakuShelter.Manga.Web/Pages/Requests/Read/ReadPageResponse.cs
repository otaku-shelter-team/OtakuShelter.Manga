using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadPageResponse
	{
		[DataMember(Name = "pages")]
		public ICollection<ReadPageItemResponse> Pages { get; private set; }

		public async ValueTask Load(MangaContext context, int chapterId, int offset, int limit)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			Pages = chapter.Pages
				.OrderBy(page => page.Order)
				.Skip(offset)
				.Take(limit)
				.Select(page => new ReadPageItemResponse(page))
				.ToList();
		}
	}
}