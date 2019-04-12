using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Mangas
{
	public class MangaTagConfiguration : IEntityTypeConfiguration<MangaTag>
	{
		public void Configure(EntityTypeBuilder<MangaTag> builder)
		{
			builder.ToTable("manga_tags");

			builder.HasKey(mt => new {mt.TagId, mt.MangaId});

			builder.Property(mt => mt.TagId)
				.HasColumnName("tag_id")
				.IsRequired();

			builder.Property(mt => mt.MangaId)
				.HasColumnName("manga_id")
				.IsRequired();

			builder.HasOne(mt => mt.Tag)
				.WithMany(t => t.Mangas)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_tag_manga_tags");

			builder.HasOne(mt => mt.Manga)
				.WithMany(t => t.Tags)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_manga_manga_tags");
		}
	}
}