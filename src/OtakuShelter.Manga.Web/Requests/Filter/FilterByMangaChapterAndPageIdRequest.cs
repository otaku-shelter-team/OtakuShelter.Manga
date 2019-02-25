using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class FilterByMangaChapterAndPageIdRequest : FilterResponse
	{
		[DataMember(Name = "mangaId")]
		public int? MangaId { get; set; }
		
		[DataMember(Name = "chapterId")]
		public int? ChapterId { get; set; }
		
		[DataMember(Name = "pageId")]
		public int? PageId { get; set; }
	}
}