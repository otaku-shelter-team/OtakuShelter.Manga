using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	public class DefaultMangaParser : IMangaParser
	{
		private readonly MangasContext context;

		public DefaultMangaParser(MangasContext context)
		{
			this.context = context;
		}

		public async Task Parse(CancellationToken cancellationToken)
		{
			var manga = await context.Mangas.FirstAsync(cancellationToken);
			
			Console.WriteLine("DONE" + manga.Title);
		}
	}
}