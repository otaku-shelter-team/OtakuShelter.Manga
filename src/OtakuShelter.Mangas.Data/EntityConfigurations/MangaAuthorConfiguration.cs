using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Mangas
{
	public class MangaAuthorConfiguration : IEntityTypeConfiguration<MangaAuthor>
	{
		public void Configure(EntityTypeBuilder<MangaAuthor> builder)
		{
			builder.ToTable("manga_authors");
			
			builder.HasKey(mt => new { mt.MangaId, TranslatorId = mt.AuthorId });

			builder.Property(mt => mt.MangaId)
				.HasColumnName("manga_id")
				.IsRequired();

			builder.Property(mt => mt.AuthorId)
				.HasColumnName("author_id")
				.IsRequired();

			builder.HasOne(mt => mt.Manga)
				.WithMany(m => m.Authors)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_manga_manga_authors");

			builder.HasOne(mt => mt.Author)
				.WithMany(t => t.Mangas)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_author_manga_authors");
		}
	}
}