using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminCreateTypeRequest
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		public async ValueTask Create(MangasContext context)
		{
			var type = new Type
			{
				Name = Name
			};

			await context.Types.AddAsync(type);
		}
	}
}