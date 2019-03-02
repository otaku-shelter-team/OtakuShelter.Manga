using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadTypeResponse
	{
		[DataMember(Name = "types")]
		public ICollection<ReadTypeItemResponse> Types { get; private set; }
		
		public async ValueTask Load(MangasContext context, int offset, int limit)
		{
			Types = await context.Types
				.AsNoTracking()
				.Skip(offset)
				.Take(limit)
				.Select(type => new ReadTypeItemResponse(type))
				.ToListAsync();
		}
	}
}