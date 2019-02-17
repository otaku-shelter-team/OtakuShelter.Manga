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
		
		public async Task Load(MangaContext context, int offset, int limit)
		{
			Authors = await context.Authors
				.AsNoTracking()
				.OrderBy(a => a.Name)
				.Skip(offset)
				.Take(limit)
				.Select(a => new ReadAuthorItemViewModel(a))
				.ToListAsync();
		}
	}
}