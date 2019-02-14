using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminCreateTagViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async Task Create(MangaContext context)
		{
			var tag = new Tag
			{
				Name = Name
			};

			await context.Tags.AddAsync(tag);
		}
	}
}