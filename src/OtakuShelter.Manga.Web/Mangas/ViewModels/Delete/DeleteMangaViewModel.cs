using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class DeleteMangaViewModel
	{
		[DataMember(Name = "mangaId")]
		public int MangaId { get; set; }

		public async Task Delete(MangaContext context)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == MangaId);

			context.Mangas.Remove(manga);
			context.MangaTags.RemoveRange(manga.Tags);
		}
	}
}