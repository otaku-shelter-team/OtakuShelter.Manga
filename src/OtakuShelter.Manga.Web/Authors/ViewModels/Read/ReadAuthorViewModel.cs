using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadAuthorViewModel
	{
		[DataMember(Name = "authors")]
		public ICollection<ReadAuthorItemViewModel> Authors { get; private set; }
		
		public async Task Load(MangaContext context, int? mangaId, int offset, int limit)
		{
			var authors = context.Authors.AsNoTracking();

			if (mangaId != null)
			{
				var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

				authors = authors.Where(a => a.Mangas.Any(ma => ma.Manga == manga));
			}
			
			Authors = await authors
				.OrderBy(a => a.Name)
				.Skip(offset)
				.Take(limit)
				.Select(a => new ReadAuthorItemViewModel(a))
				.ToListAsync();
		}
	}
}