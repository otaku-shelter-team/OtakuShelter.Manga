using System.Runtime.Serialization;
using Phema.Configuration;

namespace OtakuShelter.Manga
{
	[Configuration]
	public class OtakuShelterDataConfiguration
	{
		[DataMember(Name = "DatabaseConnectionString")]
		public string DatabaseConnectionString { get; set; }
		
		[DataMember(Name = "MigrationsAssembly")]
		public string MigrationsAssembly { get; set; }

		[DataMember(Name = "MigrationsTable")]
		public string MigrationsTable { get; set; }
		
		[DataMember(Name = "MigrationsSchema")]
		public string MigrationsSchema { get; set; }
	}
}