using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTagResponse
	{
		[DataMember(Name = "tags")]
		public ICollection<ReadTagItemResponse> Tags { get; private set; }
		
		public async ValueTask Load(MangaContext context, int offset, int limit)
		{
			Tags = await context.Tags
				.AsNoTracking()
				.OrderBy(t => t.Name)
				.Skip(offset)
				.Take(limit)
				.Select(tag => new ReadTagItemResponse(tag))
				.ToListAsync();
		}
	}
}