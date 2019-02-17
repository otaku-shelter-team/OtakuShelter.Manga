using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTranslatorViewModel
	{
		[DataMember(Name = "translators")]
		public ICollection<ReadTranslatorItemViewModel> Translators { get; private set; }
		
		public async Task Read(MangaContext context, int offset, int limit)
		{
			Translators = await context.Translators
				.AsNoTracking()
				.OrderBy(t => t.Name)
				.Skip(offset)
				.Take(limit)
				.Select(t => new ReadTranslatorItemViewModel(t))
				.ToListAsync();
		}
	}
}