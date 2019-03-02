using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadVersionResponse
	{
		[DataMember(Name = "version")]
		public string Version { get; set; }

		public void Read(MangasConfiguration configuration)
		{
			Version = configuration.Version;
		}
	}
}