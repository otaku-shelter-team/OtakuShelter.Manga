using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class DeleteChapterViewModel
	{
		[DataMember(Name = "chapterId")]
		public int ChapterId { get; set; }
		
		public async Task Delete(MangaContext context)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == ChapterId);

			context.Chapters.Remove(chapter);
			context.Pages.RemoveRange(chapter.Pages);
		}
	}
}