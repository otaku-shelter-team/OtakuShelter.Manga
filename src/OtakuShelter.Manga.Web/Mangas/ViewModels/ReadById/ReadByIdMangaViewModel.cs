using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	public class ReadByIdMangaViewModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public TypeViewModel Type { get; set; }
		public ICollection<TagViewModel> Tags { get; set; }
		
		public async Task Load(MangaContext context, int mangaId)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

			Title = manga.Title;
			Description = manga.Description;
			Type = new TypeViewModel(manga.Type);
			Tags = manga.MangaTags.Select(mt => new TagViewModel(mt.Tag)).ToList();
		}
	}
}