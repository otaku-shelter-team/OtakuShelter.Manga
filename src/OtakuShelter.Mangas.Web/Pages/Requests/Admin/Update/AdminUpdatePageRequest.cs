using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminUpdatePageRequest
	{
		[DataMember(Name = "order")]
		public int? Order { get; set; }

		[DataMember(Name = "image")]
		public string Image { get; set; }

		public async ValueTask Update(MangasContext context, int pageId)
		{
			var page = await context.Pages.FirstAsync(p => p.Id == pageId);

			if (Order != null) page.Order = Order.Value;

			if (Image != null) page.Image = Image;
		}
	}
}