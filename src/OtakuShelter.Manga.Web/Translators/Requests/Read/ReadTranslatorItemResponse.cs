using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadTranslatorItemResponse
	{
		public ReadTranslatorItemResponse(Translator translator)
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