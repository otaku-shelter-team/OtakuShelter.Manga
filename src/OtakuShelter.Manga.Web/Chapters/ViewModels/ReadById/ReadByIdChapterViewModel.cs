using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadByIdChapterViewModel
	{
		[DataMember(Name = "title")]
		public string Title { get; private set; }
		
		[DataMember(Name = "uploadDate")]
		public DateTime UploadDate { get; private set; }

		[DataMember(Name = "mangaId")]
		public int MangaId { get; private set; }
		
		public async Task Load(MangaContext context, int chapterId)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			Title = chapter.Title;
			UploadDate = chapter.UploadDate;
			MangaId = chapter.MangaId;
		}
	}
}