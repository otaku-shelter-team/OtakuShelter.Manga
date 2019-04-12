using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadByIdPageResponse
	{
		[DataMember(Name = "order")]
		public int Order { get; private set; }

		[DataMember(Name = "image")]
		public string Image { get; private set; }

		[DataMember(Name = "chapterId")]
		public int ChapterId { get; private set; }

		public async ValueTask Load(MangasContext context, int pageId)
		{
			var page = await context.Pages.FirstAsync(p => p.Id == pageId);

			Order = page.Order;
			Image = page.Image;
			ChapterId = page.ChapterId;
		}
	}
}