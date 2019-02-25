using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminCreatePageRequest
	{
		[DataMember(Name = "order")]
		public int Order { get; set; }
		
		[DataMember(Name = "image")]
		public string Image { get; set; }
      
		public async ValueTask Create(MangaContext context, int chapterId)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			var page = new Page
			{
				Order = Order,
				Chapter = chapter,
				Image = Image
			};

			await context.Pages.AddAsync(page);
		}
	}
}