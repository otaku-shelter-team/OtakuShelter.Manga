using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminDeleteAuthorRequest
	{
		[DataMember(Name = "authorId")]
		public int AuthorId { get; set; }

		public async ValueTask Delete(MangasContext context)
		{
			var author = await context.Authors.FirstAsync(t => t.Id == AuthorId);

			context.Authors.Remove(author);
		}
	}
}