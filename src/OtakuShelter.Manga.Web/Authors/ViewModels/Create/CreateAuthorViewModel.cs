using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class CreateAuthorViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async Task Create(MangaContext context)
		{
			var author = new Author
			{
				Name = Name
			};

			await context.Authors.AddAsync(author);
		}
	}
}