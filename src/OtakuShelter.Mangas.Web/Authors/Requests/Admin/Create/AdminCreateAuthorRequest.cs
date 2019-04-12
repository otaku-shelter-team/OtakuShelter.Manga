using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminCreateAuthorRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		public async ValueTask Create(MangasContext context)
		{
			var author = new Author
			{
				Name = Name
			};

			await context.Authors.AddAsync(author);
		}
	}
}