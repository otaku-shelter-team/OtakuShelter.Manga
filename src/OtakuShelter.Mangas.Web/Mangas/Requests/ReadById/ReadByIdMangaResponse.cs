using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadByIdMangaResponse
	{
		[DataMember(Name = "title")]
		public string Title { get; private set; }

		[DataMember(Name = "description")]
		public string Description { get; private set; }

		[DataMember(Name = "image")]
		public string Image { get; private set; }

		[DataMember(Name = "type")]
		public ReadTypeItemResponse Type { get; private set; }

		public async ValueTask ReadById(MangasContext context, int mangaId)
		{
			var manga = await context.Mangas
				.Include(m => m.Type)
				.FirstAsync(m => m.Id == mangaId);

			Title = manga.Title;
			Description = manga.Description;
			Image = manga.Image;
			Type = new ReadTypeItemResponse(manga.Type);
		}
	}
}