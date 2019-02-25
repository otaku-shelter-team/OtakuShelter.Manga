using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AuthorResponse
	{
		public AuthorResponse()
		{
		}

		public AuthorResponse(Author author)
		{
			Id = author.Id;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}