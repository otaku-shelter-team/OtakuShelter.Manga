using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadMangaAuthorsByIdItemViewModel
	{
		public ReadMangaAuthorsByIdItemViewModel(Author author)
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