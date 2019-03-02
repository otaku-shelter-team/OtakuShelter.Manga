using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminUpdateTranslatorRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async ValueTask Update(MangasContext context, int translatorId)
		{
			var translator = await context.Translators.FirstAsync(t => t.Id == translatorId);

			if (Name != null)
			{
				translator.Name = Name;
			}
		}
	}
}