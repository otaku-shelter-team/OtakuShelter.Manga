using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTagItemViewModel
	{
		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "name")]
		public string Name { get; }
		
		public ReadTagItemViewModel(Tag tag)
		{
			Id = tag.Id;
			Name = tag.Name;
		}
	}
}