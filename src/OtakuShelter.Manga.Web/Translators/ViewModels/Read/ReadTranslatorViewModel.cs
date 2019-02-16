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
		
		public async Task Load(MangaContext context, int? mangaId, int offset, int limit)
		{
			var translators = context.Translators.AsNoTracking();

			if (mangaId != null)
			{
				var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

				translators = translators.Where(t => t.Mangas.Any(mt => mt.Manga == manga));
			}
			
			Translators = await translators
				.OrderBy(t => t.Name)
				.Skip(offset)
				.Take(limit)
				.Select(t => new ReadTranslatorItemViewModel(t))
				.ToListAsync();
		}
	}
}