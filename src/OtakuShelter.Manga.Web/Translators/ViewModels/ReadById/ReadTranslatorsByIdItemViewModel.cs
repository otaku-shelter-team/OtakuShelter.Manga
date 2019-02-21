using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTranslatorsByIdItemViewModel
	{
		public ReadTranslatorsByIdItemViewModel(Translator translator)
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