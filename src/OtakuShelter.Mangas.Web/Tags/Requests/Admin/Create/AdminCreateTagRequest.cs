using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminCreateTagRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async ValueTask Create(MangasContext context)
		{
			var tag = new Tag
			{
				Name = Name
			};

			await context.Tags.AddAsync(tag);
		}
	}
}