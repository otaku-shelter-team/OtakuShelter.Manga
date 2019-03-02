using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadMangaItemResponse
	{
		public ReadMangaItemResponse(Manga manga)
		{
			Id = manga.Id;
			Title = manga.Title;
			Description = manga.Description;
			Image = manga.Image;
		}

		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "title")]
		public string Title { get; }
		
		[DataMember(Name = "description")]
		public string Description { get; }
		
		[DataMember(Name = "image")]
		public string Image { get; }
	}
}