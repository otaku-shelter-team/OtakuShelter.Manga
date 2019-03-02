using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class FilterResponse
	{
		public FilterResponse()
		{
		}
		
		[DataMember(Name = "offset")]
		public int Offset { get; set; } = 0;
		
		[DataMember(Name = "limit")]
		public int Limit { get; set; } = 20;
	}
}