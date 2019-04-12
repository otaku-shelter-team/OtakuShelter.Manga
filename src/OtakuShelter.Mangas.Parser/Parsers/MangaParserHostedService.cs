using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace OtakuShelter.Mangas
{
	public class MangaParserHostedService : IHostedService
	{
		private readonly IEnumerable<IMangaParser> parsers;

		public MangaParserHostedService(IEnumerable<IMangaParser> parsers)
		{
			this.parsers = parsers;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			foreach (var parser in parsers) await parser.Parse(cancellationToken);
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}