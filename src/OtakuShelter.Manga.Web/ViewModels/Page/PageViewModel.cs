using System.Runtime.Serialization;

namespace OtakuShelter.Manga.ViewModels.Page
{
	[DataContract]
	public class PageViewModel
	{
		public PageViewModel()
		{
		}

		public PageViewModel(int offset, int limit)
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