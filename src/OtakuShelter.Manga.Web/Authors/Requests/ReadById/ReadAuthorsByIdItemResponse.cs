using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadAuthorsByIdItemResponse
	{
		public ReadAuthorsByIdItemResponse(Author author)
		{
			Id = author.Id;
			Name = author.Name;
		}

		[DataMember(Name = "id")]
		public int Id { get; }

		[DataMember(Name = "name")]
		public string Name { get; }
	}
}