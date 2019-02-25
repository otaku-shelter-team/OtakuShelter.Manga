using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminDeleteMangaRequest
	{
		[DataMember(Name = "mangaId")]
		public int MangaId { get; set; }

		public async ValueTask Delete(MangaContext context)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == MangaId);

			context.Mangas.Remove(manga);
			context.MangaTags.RemoveRange(manga.Tags);
		}
	}
}