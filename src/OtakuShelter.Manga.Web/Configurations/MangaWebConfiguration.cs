using System.Text;

using Microsoft.IdentityModel.Tokens;

using Phema.Configuration;

namespace OtakuShelter.Manga
{
	[Configuration]
	public class MangaWebConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		
		public MangaRoleConfiguration Roles { get; set; }
		public MangaContextConfiguration Database { get; set; }

		public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
	}
}