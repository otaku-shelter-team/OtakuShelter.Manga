using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Mangas
{
	public class TranslatorConfiguration : IEntityTypeConfiguration<Translator>
	{
		public void Configure(EntityTypeBuilder<Translator> builder)
		{
			builder.ToTable("translators");

			builder.Property(t => t.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(t => t.Name)
				.HasColumnName("name")
				.HasMaxLength(500)
				.IsRequired();

			builder.HasIndex(t => t.Name)
				.IsUnique()
				.HasName("ux_translators_name");
		}
	}
}