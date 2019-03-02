using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminCreateChapterRequest
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "order")]
		public int Order { get; set; }
		
		[DataMember(Name = "uploadDate")]
		public DateTime UploadDate { get; set; }
		
		public async ValueTask Create(MangasContext context, int mangaId)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);
			
			var chapter = new Chapter
			{
				Title = Title,
				Order =  Order,
				UploadDate = UploadDate,
				Manga = manga
			};

			await context.Chapters.AddAsync(chapter);
		}
	}
}