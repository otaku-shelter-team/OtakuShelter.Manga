using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadAuthorResponse
	{
		[DataMember(Name = "authors")]
		public ICollection<ReadAuthorItemRequest> Authors { get; private set; }

		public async ValueTask Load(MangasContext context, int offset, int limit)
		{
			Authors = await context.Authors
				.AsNoTracking()
				.OrderBy(a => a.Name)
				.Skip(offset)
				.Take(limit)
				.Select(author => new ReadAuthorItemRequest(author))
				.ToListAsync();
		}
	}
}