using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class FilterViewModel
	{
		public FilterViewModel()
		{
		}

		public FilterViewModel(int offset, int limit)
		{
			Offset = offset;
			Limit = limit;
		}
		
		[DataMember(Name = "offset")]
		public int Offset { get; set; } = 0;
		
		[DataMember(Name = "limit")]
		public int Limit { get; set; } = 20;
	}
}