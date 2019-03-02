using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminUpdateTypeRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async ValueTask Update(MangasContext context, int typeId)
		{
			var type = await context.Types.FirstAsync(t => t.Id == typeId);

			if (Name != null)
			{
				type.Name = Name;
			}
		}
	}
}