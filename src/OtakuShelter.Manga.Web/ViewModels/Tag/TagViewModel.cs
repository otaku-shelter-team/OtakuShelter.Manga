using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class TagViewModel
	{
		public TagViewModel()
		{
		}

		public TagViewModel(Tag tag)
		{
			Id = tag.Id;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}