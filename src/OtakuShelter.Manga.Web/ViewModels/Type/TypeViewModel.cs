using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class TypeViewModel
	{
		public TypeViewModel()
		{
		}
		
		public TypeViewModel(Type type)
		{
			Id = type.Id;
			Name = type.Name;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}