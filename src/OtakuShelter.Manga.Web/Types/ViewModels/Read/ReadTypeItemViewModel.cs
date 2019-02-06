using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTypeItemViewModel
	{
		public ReadTypeItemViewModel(Type type)
		{
			Id = type.Id;
			Name = type.Name;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "name")]
		public string Name { get; }
	}
}