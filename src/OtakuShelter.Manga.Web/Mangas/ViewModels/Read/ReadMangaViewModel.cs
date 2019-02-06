using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadMangaViewModel
	{
		[DataMember(Name = "mangas")]
		public ICollection<ReadMangaItemViewModel> Mangas { get; private set; }
		
		public async Task Load(MangaContext context, int offset, int limit)
		{
			Mangas = await context.Mangas
				.Skip(offset)
				.Take(limit)
				.Select(m => new ReadMangaItemViewModel(m))
				.ToListAsync();
		}
	}
}