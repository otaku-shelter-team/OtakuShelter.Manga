using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadTypeItemResponse
	{
		public ReadTypeItemResponse(Type type)
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