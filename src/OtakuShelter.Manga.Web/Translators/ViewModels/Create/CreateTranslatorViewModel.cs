using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class CreateTranslatorViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async Task Create(MangaContext context)
		{
			var translator = new Translator
			{
				Name = Name
			};

			await context.Translators.AddAsync(translator);
		}
	}
}