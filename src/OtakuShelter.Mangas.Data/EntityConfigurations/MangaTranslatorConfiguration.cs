using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Mangas
{
	public class MangaTranslatorConfiguration : IEntityTypeConfiguration<MangaTranslator>
	{
		public void Configure(EntityTypeBuilder<MangaTranslator> builder)
		{
			builder.ToTable("manga_translators");

			builder.HasKey(mt => new {mt.MangaId, mt.TranslatorId});

			builder.Property(mt => mt.MangaId)
				.HasColumnName("manga_id")
				.IsRequired();

			builder.Property(mt => mt.TranslatorId)
				.HasColumnName("translator_id")
				.IsRequired();

			builder.HasOne(mt => mt.Manga)
				.WithMany(m => m.Translators)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_manga_manga_translators");

			builder.HasOne(mt => mt.Translator)
				.WithMany(t => t.Mangas)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_translator_manga_translators");
		}
	}
}