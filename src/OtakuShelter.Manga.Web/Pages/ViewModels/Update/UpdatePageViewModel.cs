using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class UpdatePageViewModel
	{
		[DataMember(Name = "image")]
		public string Image { get; set; }
		
		public async Task Update(MangaContext context, int pageId)
		{
			var page = await context.Pages.FirstAsync(p => p.Id == pageId);

			if (Image != null)
			{
				page.Image = Image;
			}
		}
	}
}