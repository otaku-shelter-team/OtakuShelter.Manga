using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadTranslatorsByIdItemResponse
	{
		public ReadTranslatorsByIdItemResponse(Translator translator)
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