using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTagsByIdItemViewModel
	{
		public ReadTagsByIdItemViewModel(Tag tag)
		{
			Id = tag.Id;
			Name = tag.Name;
		}

		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "name")]
		public string Name { get; }
	}
}