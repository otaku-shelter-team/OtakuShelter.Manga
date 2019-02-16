using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class FilterByMangaIdViewModel : FilterViewModel
	{
		[DataMember(Name = "mangaId")]
		public int? MangaId { get; set; }
	}
}