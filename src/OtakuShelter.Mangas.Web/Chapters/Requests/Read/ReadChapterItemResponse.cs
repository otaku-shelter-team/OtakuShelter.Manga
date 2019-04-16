using System;
using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadChapterItemResponse
	{
		public ReadChapterItemResponse(Chapter chapter)
		{
			Id = chapter.Id;
			Title = chapter.Title;
			UploadDate = chapter.UploadDate;
		}

		[DataMember(Name = "id")]
		public int Id { get; }

		[DataMember(Name = "title")]
		public string Title { get; }
		
		[DataMember(Name = "uploadDate")]
		public DateTime UploadDate { get; }
	}
}