using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadMangaResponse
	{
		[DataMember(Name = "mangas")]
		public ICollection<ReadMangaItemResponse> Mangas { get; private set; }

		public async ValueTask Load(MangasContext context, FilterByMangaRequest filter)
		{
			var query = context.Mangas.AsNoTracking();

			if (filter.Title != null)
			{
				query = query.Where(m => m.Title.Contains(filter.Title));
			}

			if (filter.Tags != null)
			{
				query = query.Include(m => m.Tags)
					.Where(m => m.Tags.Any(t => filter.Tags.Contains(t.TagId)));
			}

			Mangas = await query
				.OrderByDescending(m => m.Id)
				.Skip(filter.Offset)
				.Take(filter.Limit)
				.Select(manga => new ReadMangaItemResponse(manga))
				.ToListAsync();
		}
	}
}