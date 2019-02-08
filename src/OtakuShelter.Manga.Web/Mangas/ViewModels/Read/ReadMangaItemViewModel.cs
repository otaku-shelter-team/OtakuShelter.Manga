using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadMangaItemViewModel
	{
		public ReadMangaItemViewModel(Manga manga)
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