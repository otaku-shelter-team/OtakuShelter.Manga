using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminCreatePageViewModel
	{
		[DataMember(Name = "image")]
		public string Image { get; set; }
      
		public async Task Create(MangaContext context, int chapterId)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			var page = new Page
			{
				Chapter = chapter,
				Image = Image
			};

			await context.Pages.AddAsync(page);
		}
	}
}