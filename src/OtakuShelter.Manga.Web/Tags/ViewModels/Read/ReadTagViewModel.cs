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
		
		public async Task Load(MangaContext context, int offset, int limit)
		{
			Tags = await context.Tags
				.Skip(offset)
				.Take(limit)
				.Select(t => new ReadTagItemViewModel(t))
				.ToListAsync();
		}
	}
}