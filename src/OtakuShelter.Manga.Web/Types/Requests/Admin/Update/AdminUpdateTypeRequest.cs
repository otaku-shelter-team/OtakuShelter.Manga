using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminUpdateTypeRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async ValueTask Update(MangaContext context, int typeId)
		{
			var type = await context.Types.FirstAsync(t => t.Id == typeId);

			if (Name != null)
			{
				type.Name = Name;
			}
		}
	}
}