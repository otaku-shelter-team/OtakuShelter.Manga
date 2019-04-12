using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class FilterByMangaChapterAndPageIdRequest : FilterRequest
	{
		[DataMember(Name = "mangaId")]
		public int? MangaId { get; set; }

		[DataMember(Name = "chapterId")]
		public int? ChapterId { get; set; }

		[DataMember(Name = "pageId")]
		public int? PageId { get; set; }
	}
}