using System.Threading;
using System.Threading.Tasks;

namespace OtakuShelter.Mangas
{
	public interface IMangaParser
	{
		Task Parse(CancellationToken cancellationToken);
	}
}