using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadMangaTranslatorsByIdItemViewModel
	{
		public ReadMangaTranslatorsByIdItemViewModel(Translator translator)
		{
			Id = translator.Id;
			Name = translator.Name;
		}

		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "name")]
		public string Name { get; }
	}
}