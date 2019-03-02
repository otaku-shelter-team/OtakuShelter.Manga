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
		
		public async ValueTask Load(MangasContext context, int offset, int limit)
		{
			Mangas = await context.Mangas
				.AsNoTracking()
				.OrderByDescending(m => m.Id)
				.Skip(offset)
				.Take(limit)
				.Select(manga => new ReadMangaItemResponse(manga))
				.ToListAsync();
		}
	}
}