namespace OtakuShelter.Mangas
{
	public class MangasConfiguration
	{
		public string Name { get; set; }
		public string Version { get; set; }

		public string FrontendOrigin { get; set; }

		public MangasDatabaseConfiguration Database { get; set; }
		public MangasJwtConfiguration Jwt { get; set; }
		public MangasRabbitMqConfiguration RabbitMq { get; set; }
		public MangasRoleConfiguration Roles { get; set; }
	}
}