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

		public async ValueTask Load(MangasContext context, FilterByMangaTitleRequest filter)
		{
			var query = context.Mangas
				.AsNoTracking()
				.OrderByDescending(m => m.Id)
				.Skip(filter.Offset)
				.Take(filter.Limit);

			if (filter.Title != null) query = query.Where(m => m.Title == filter.Title);

			Mangas = await query
				.Select(manga => new ReadMangaItemResponse(manga))
				.ToListAsync();
		}
	}
}