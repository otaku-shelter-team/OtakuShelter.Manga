using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminUpdateChapterViewModel
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }
		
		[DataMember(Name = "uploadDate")]
		public DateTime? UploadDate { get; set; }
		
		public async Task Update(MangaContext context, int chapterId)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			if (Title != null)
			{
				chapter.Title = Title;
			}

			if (UploadDate != null)
			{
				chapter.UploadDate = UploadDate.Value;
			}
		}
	}
}