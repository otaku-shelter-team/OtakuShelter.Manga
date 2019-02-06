using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadByIdPageViewModel
	{
		[DataMember(Name = "image")]
		public string Image { get; private set; }
		
		[DataMember(Name = "chapterId")]
		public int ChapterId { get; private set; }
		
		public async Task Load(MangaContext context, int pageId)
		{
			var page = await context.Pages.FirstAsync(p => p.Id == pageId);

			Image = page.Image;
			ChapterId = page.ChapterId;
		}
	}
}