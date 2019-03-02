using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminUpdateChapterRequest
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "order")]
		public int? Order { get; set; }
		
		[DataMember(Name = "uploadDate")]
		public DateTime? UploadDate { get; set; }
		
		public async ValueTask Update(MangasContext context, int chapterId)
		{
			var chapter = await context.Chapters.FirstAsync(ch => ch.Id == chapterId);

			if (Title != null)
			{
				chapter.Title = Title;
			}

			if (Order != null)
			{
				chapter.Order = Order.Value;
			}

			if (UploadDate != null)
			{
				chapter.UploadDate = UploadDate.Value;
			}
		}
	}
}