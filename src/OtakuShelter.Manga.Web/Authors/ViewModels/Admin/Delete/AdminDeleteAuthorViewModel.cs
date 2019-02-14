using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminDeleteAuthorViewModel
	{
		[DataMember(Name = "authorId")]
		public int AuthorId { get; set; }
		
		public async Task Delete(MangaContext context)
		{
			var author = await context.Authors.FirstAsync(t => t.Id == AuthorId);

			context.Authors.Remove(author);
		}
	}
}