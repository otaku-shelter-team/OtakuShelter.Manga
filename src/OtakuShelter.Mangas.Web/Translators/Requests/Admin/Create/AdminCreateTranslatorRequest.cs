using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminCreateTranslatorRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async ValueTask Create(MangasContext context)
		{
			var translator = new Translator
			{
				Name = Name
			};

			await context.Translators.AddAsync(translator);
		}
	}
}