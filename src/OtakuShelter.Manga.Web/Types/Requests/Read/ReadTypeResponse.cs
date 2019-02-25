using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTypeResponse
	{
		[DataMember(Name = "types")]
		public ICollection<ReadTypeItemResponse> Types { get; private set; }
		
		public async ValueTask Load(MangaContext context, int offset, int limit)
		{
			Types = await context.Types
				.Skip(offset)
				.Take(limit)
				.Select(t => new ReadTypeItemResponse(t))
				.ToListAsync();
		}
	}
}