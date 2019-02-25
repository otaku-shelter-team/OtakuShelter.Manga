using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class TranslatorResponse
	{
		public TranslatorResponse()
		{
		}

		public TranslatorResponse(Translator translator)
		{
			Id = translator.Id;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}