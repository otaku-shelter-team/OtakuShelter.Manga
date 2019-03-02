using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class TypeResponse
	{
		public TypeResponse()
		{
		}
		
		public TypeResponse(Type type)
		{
			Id = type.Id;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}