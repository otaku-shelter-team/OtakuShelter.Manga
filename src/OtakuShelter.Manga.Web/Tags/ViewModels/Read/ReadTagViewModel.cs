using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTagViewModel
	{
		[DataMember(Name = "tags")]
		public ICollection<ReadTagItemViewModel> Tags { get; private set; }
		
		public async Task Load(MangaContext context, int? mangaId, int offset, int limit)
		{
			var tags = context.Tags.AsNoTracking();

			if (mangaId != null)
			{
				var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

				tags = tags.Where(t => t.Mangas.Any(mt => mt.Manga == manga));
			}
			
			Tags = await tags
				.OrderBy(t => t.Name)
				.Skip(offset)
				.Take(limit)
				.Select(t => new ReadTagItemViewModel(t))
				.ToListAsync();
		}
	}
}