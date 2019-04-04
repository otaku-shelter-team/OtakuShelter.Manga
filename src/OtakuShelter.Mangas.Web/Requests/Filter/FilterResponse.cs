using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class FilterResponse
	{
		[DataMember(Name = "offset")]
		public int Offset { get; set; }
		
		[DataMember(Name = "limit")]
		public int Limit { get; set; } = 20;
	}
}