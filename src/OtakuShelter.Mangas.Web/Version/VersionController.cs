using Microsoft.Extensions.Options;

namespace OtakuShelter.Mangas
{
	public class VersionController
	{
		private readonly MangasConfiguration configuration;

		public VersionController(IOptions<MangasConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public ReadVersionResponse Version()
		{
			var response = new ReadVersionResponse();

			response.Read(configuration);

			return response;
		}
	}
}