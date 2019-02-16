using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class FilterByMangaChapterAndPageIdViewModel : FilterViewModel
	{
		[DataMember(Name = "mangaId")]
		public int MangaId { get; set; }
		
		[DataMember(Name = "chapterId")]
		public int? ChapterId { get; set; }
		
		[DataMember(Name = "pageId")]
		public int? PageId { get; set; }
	}
}