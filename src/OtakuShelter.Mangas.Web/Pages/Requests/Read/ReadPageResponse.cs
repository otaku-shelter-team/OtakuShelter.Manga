using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadPageResponse
	{
		[DataMember(Name = "pages")]
		public ICollection<ReadPageItemResponse> Pages { get; private set; }

		public async ValueTask Load(MangasContext context, int chapterId, int offset, int limit)
		{
			Pages = await context.Pages
				.Where(p => p.ChapterId == chapterId)
				.OrderBy(page => page.Order)
				.Skip(offset)
				.Take(limit)
				.Select(page => new ReadPageItemResponse(page))
				.ToListAsync();
		}
	}
}