using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Mangas
{
	public class MangaTranslatorConfiguration : IEntityTypeConfiguration<MangaTranslator>
	{
		public void Configure(EntityTypeBuilder<MangaTranslator> builder)
		{
			builder.ToTable("mangatranslators");
			
			builder.HasKey(mt => new { mt.MangaId, mt.TranslatorId });

			builder.Property(mt => mt.MangaId)
				.HasColumnName("mangaid")
				.IsRequired();

			builder.Property(mt => mt.TranslatorId)
				.HasColumnName("translatorid")
				.IsRequired();

			builder.HasOne(mt => mt.Manga)
				.WithMany(m => m.Translators)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_manga_mangatranslators");

			builder.HasOne(mt => mt.Translator)
				.WithMany(t => t.Mangas)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_translator_mangatranslators");
		}
	}
}