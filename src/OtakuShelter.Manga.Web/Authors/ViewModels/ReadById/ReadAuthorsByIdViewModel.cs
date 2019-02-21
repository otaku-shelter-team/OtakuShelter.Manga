using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadAuthorsByIdViewModel
	{
		[DataMember(Name = "authors")]
		public ICollection<ReadAuthorsByIdItemViewModel> Authors { get; private set; }		

		public async Task Read(MangaContext context, int mangaId, int offset, int limit)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

			Authors = await context.MangaAuthors
				.AsNoTracking()
				.Where(ma => ma.Manga == manga)
				.Select(ma => ma.Author)
				.OrderBy(a => a.Name)
				.Skip(offset)
				.Take(limit)
				.Select(a => new ReadAuthorsByIdItemViewModel(a))
				.ToListAsync();
		}
	}
}