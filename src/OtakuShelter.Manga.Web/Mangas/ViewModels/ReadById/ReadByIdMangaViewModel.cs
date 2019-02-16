using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadByIdMangaViewModel
	{
		[DataMember(Name = "title")]
		public string Title { get; private set; }
		
		[DataMember(Name = "description")]
		public string Description { get; private set; }
		
		[DataMember(Name = "image")]
		public string Image { get; private set; }
		
		[DataMember(Name = "type")]
		public ReadTypeItemViewModel Type { get; private set; }
		
		public async Task Load(MangaContext context, int mangaId)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);

			Title = manga.Title;
			Description = manga.Description;
			Image = manga.Image;
			Type = new ReadTypeItemViewModel(manga.Type);
		}
	}
}