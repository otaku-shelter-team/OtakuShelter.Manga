using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class CreateChapterViewModel
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }
		
		[DataMember(Name = "uploadDate")]
		public DateTime UploadDate { get; set; }
		
		public async Task Create(MangaContext context, int mangaId)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);
			
			var chapter = new Chapter
			{
				Title = Title,
				UploadDate = UploadDate,
				Manga = manga
			};

			await context.Chapters.AddAsync(chapter);
		}
	}
}