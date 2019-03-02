using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadAuthorsByIdResponse
	{
		[DataMember(Name = "authors")]
		public ICollection<ReadAuthorsByIdItemResponse> Authors { get; private set; }		

		public async ValueTask Read(MangasContext context, int mangaId, int offset, int limit)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

			Authors = await context.MangaAuthors
				.AsNoTracking()
				.Where(ma => ma.Manga == manga)
				.Select(ma => ma.Author)
				.OrderBy(a => a.Name)
				.Skip(offset)
				.Take(limit)
				.Select(a => new ReadAuthorsByIdItemResponse(a))
				.ToListAsync();
		}
	}
}