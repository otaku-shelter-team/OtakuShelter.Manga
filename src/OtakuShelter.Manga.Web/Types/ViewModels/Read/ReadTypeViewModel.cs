using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTypeViewModel
	{
		[DataMember(Name = "types")]
		public ICollection<ReadTypeItemViewModel> Types { get; private set; }
		
		public async Task Load(MangaContext context, int offset, int limit)
		{
			Types = await context.Types
				.Skip(offset)
				.Take(limit)
				.Select(t => new ReadTypeItemViewModel(t))
				.ToListAsync();
		}
	}
}