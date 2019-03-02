using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminDeleteMangaRequest
	{
		[DataMember(Name = "mangaId")]
		public int MangaId { get; set; }

		public async ValueTask Delete(MangasContext context)
		{
			var manga = await context.Mangas
				.Include(m => m.Tags)
				.FirstAsync(m => m.Id == MangaId);

			context.Mangas.Remove(manga);
			context.MangaTags.RemoveRange(manga.Tags);
		}
	}
}