using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadByIdChapterResponse
	{
		[DataMember(Name = "title")]
		public string Title { get; private set; }

		[DataMember(Name = "order")]
		public int Order { get; private set; }
		
		[DataMember(Name = "uploadDate")]
		public DateTime UploadDate { get; private set; }

		[DataMember(Name = "mangaId")]
		public int MangaId { get; private set; }
		
		public async ValueTask Load(MangasContext context, int chapterId)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			Title = chapter.Title;
			Order = chapter.Order;
			UploadDate = chapter.UploadDate;
			MangaId = chapter.MangaId;
		}
	}
}