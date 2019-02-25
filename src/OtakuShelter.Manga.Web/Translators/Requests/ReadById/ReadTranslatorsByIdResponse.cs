using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	public class ReadTranslatorsByIdResponse
	{
		[DataMember(Name = "translators")]
		public ICollection<ReadTranslatorsByIdItemResponse> Translators { get; private set; }		

		public async ValueTask Read(MangaContext context, int mangaId, int offset, int limit)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

			Translators = await context.MangaTranslators
				.AsNoTracking()
				.Where(ma => ma.Manga == manga)
				.Select(ma => ma.Translator)
				.OrderBy(a => a.Name)
				.Skip(offset)
				.Take(limit)
				.Select(translator => new ReadTranslatorsByIdItemResponse(translator))
				.ToListAsync();
		}
	}
}