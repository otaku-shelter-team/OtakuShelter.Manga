using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class DeleteTranslatorViewModel
	{
		[DataMember(Name = "translatorId")]
		public int TranslatorId { get; set; }
		
		public async Task Delete(MangaContext context)
		{
			var translator = await context.Translators.FirstAsync(t => t.Id == TranslatorId);

			context.Translators.Remove(translator);
		}
	}
}