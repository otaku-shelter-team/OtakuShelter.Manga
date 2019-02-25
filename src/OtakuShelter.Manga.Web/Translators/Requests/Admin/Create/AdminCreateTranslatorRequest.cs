using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminCreateTranslatorRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async ValueTask Create(MangaContext context)
		{
			var translator = new Translator
			{
				Name = Name
			};

			await context.Translators.AddAsync(translator);
		}
	}
}