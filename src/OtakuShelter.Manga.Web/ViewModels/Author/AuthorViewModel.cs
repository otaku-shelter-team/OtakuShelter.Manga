using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AuthorViewModel
	{
		public AuthorViewModel()
		{
		}

		public AuthorViewModel(Author author)
		{
			Id = author.Id;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}