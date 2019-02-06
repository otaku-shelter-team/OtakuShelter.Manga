using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class CreateTypeViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async Task Create(MangaContext context)
		{
			var type = new Type
			{
				Name = Name
			};

			await context.Types.AddAsync(type);
		}
	}
}