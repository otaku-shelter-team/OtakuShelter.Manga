using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	public class ReadMangaTranslatorsByIdViewModel
	{
		[DataMember(Name = "translators")]
		public ICollection<ReadMangaTranslatorsByIdItemViewModel> Translators { get; private set; }		

		public async Task Read(MangaContext context, int mangaId, int offset, int limit)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

			Translators = await context.MangaTranslators
				.AsNoTracking()
				.Where(ma => ma.Manga == manga)
				.Select(ma => ma.Translator)
				.OrderBy(a => a.Name)
				.Skip(offset)
				.Take(limit)
				.Select(translator => new ReadMangaTranslatorsByIdItemViewModel(translator))
				.ToListAsync();
		}
	}
}