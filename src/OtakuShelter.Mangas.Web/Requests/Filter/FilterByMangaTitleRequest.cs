using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class FilterByMangaTitleRequest : FilterRequest
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }
	}
}