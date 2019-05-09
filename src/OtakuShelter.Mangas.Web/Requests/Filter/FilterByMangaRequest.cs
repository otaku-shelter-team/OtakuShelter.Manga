using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class FilterByMangaRequest : FilterRequest
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "tags")]
		public int[] Tags { get; set; }
	}
}