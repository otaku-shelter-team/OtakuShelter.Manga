using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminDeleteTranslatorRequest
	{
		[DataMember(Name = "translatorId")]
		public int TranslatorId { get; set; }
		
		public async ValueTask Delete(MangasContext context)
		{
			var translator = await context.Translators.FirstAsync(t => t.Id == TranslatorId);

			context.Translators.Remove(translator);
		}
	}
}