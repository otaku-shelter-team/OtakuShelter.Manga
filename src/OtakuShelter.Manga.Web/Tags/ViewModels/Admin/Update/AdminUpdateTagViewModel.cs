using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminUpdateTagViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		public async Task Update(MangaContext context, int tagId)
		{
			var tag = await context.Tags.FirstAsync(t => t.Id == tagId);

			if (Name != null)
			{
				tag.Name = Name;
			}
		}
	}
}