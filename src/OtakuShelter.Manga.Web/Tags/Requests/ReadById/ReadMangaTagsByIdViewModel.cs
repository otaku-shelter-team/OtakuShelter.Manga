using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTagsByIdResponse
	{
		[DataMember(Name = "tags")]
		public ICollection<ReadTagsByIdItemResponse> Tags { get; private set; }		

		public async ValueTask Read(MangaContext context, int mangaId, int offset, int limit)
		{
			Tags = await context.MangaTags
				.AsNoTracking()
				.Where(ma => ma.MangaId == mangaId)
				.Select(ma => ma.Tag)
				.OrderBy(a => a.Name)
				.Skip(offset)
				.Take(limit)
				.Select(tag => new ReadTagsByIdItemResponse(tag))
				.ToListAsync();
		}
	}
}