using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminUpdateAuthorViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async Task Update(MangaContext context, int authorId)
		{
			var author = await context.Authors.FirstAsync(t => t.Id == authorId);

			if (Name != null)
			{
				author.Name = Name;
			}
		}
	}
}