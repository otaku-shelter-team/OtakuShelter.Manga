using System.Runtime.Serialization;
using Phema.Configuration;

namespace OtakuShelter.Manga
{
	[Configuration]
	public class OtakuShelterWebConfiguration
	{
		[DataMember(Name = "DataConfiguration")]
		public OtakuShelterDataConfiguration DataConfiguration { get; set; }
	}
}