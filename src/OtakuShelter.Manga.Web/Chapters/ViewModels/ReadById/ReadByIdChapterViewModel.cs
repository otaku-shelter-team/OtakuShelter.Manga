using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	public class ReadByIdChapterViewModel
	{
		public string Title { get; set; }
		public DateTime UploadDate { get; set; }
		
		public async Task Load(MangaContext context, int chapterId)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			Title = chapter.Title;
			UploadDate = chapter.UploadDate;
		}
	}
}