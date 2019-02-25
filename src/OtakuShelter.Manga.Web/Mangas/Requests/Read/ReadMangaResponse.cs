using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadMangaResponse
	{
		[DataMember(Name = "mangas")]
		public ICollection<ReadMangaItemResponse> Mangas { get; private set; }
		
		public async ValueTask Load(MangaContext context, int offset, int limit)
		{
			Mangas = await context.Mangas
				.Skip(offset)
				.Take(limit)
				.Select(m => new ReadMangaItemResponse(m))
				.ToListAsync();
		}
	}
}