using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadTagsByIdItemResponse
	{
		public ReadTagsByIdItemResponse(Tag tag)
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