using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminUpdateTagRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		public async ValueTask Update(MangasContext context, int tagId)
		{
			var tag = await context.Tags.FirstAsync(t => t.Id == tagId);

			if (Name != null)
			{
				tag.Name = Name;
			}
		}
	}
}