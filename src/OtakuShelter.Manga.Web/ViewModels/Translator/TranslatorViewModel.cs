using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class TranslatorViewModel
	{
		public TranslatorViewModel()
		{
		}

		public TranslatorViewModel(Translator translator)
		{
			Id = translator.Id;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}