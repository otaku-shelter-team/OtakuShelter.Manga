using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminUpdateAuthorRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		public async ValueTask Update(MangasContext context, int authorId)
		{
			var author = await context.Authors.FirstAsync(t => t.Id == authorId);

			if (Name != null) author.Name = Name;
		}
	}
}