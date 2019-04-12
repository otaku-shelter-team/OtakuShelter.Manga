using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	public class ReadTranslatorsByIdResponse
	{
		[DataMember(Name = "translators")]
		public ICollection<ReadTranslatorsByIdItemResponse> Translators { get; private set; }

		public async ValueTask Read(MangasContext context, int mangaId, int offset, int limit)
		{
			Translators = await context.MangaTranslators
				.AsNoTracking()
				.Where(ma => ma.MangaId == mangaId)
				.Select(ma => ma.Translator)
				.OrderBy(a => a.Name)
				.Skip(offset)
				.Take(limit)
				.Select(translator => new ReadTranslatorsByIdItemResponse(translator))
				.ToListAsync();
		}
	}
}