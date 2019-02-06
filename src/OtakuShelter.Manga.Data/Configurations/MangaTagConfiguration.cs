using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Manga
{
	public class MangaTagConfiguration : IEntityTypeConfiguration<MangaTag>
	{
		public void Configure(EntityTypeBuilder<MangaTag> builder)
		{
			builder.ToTable("mangatags");
			
			builder.HasKey(mt => new { mt.TagId, mt.MangaId });

			builder.Property(mt => mt.TagId)
				.HasColumnName("tagid")
				.IsRequired();

			builder.Property(mt => mt.MangaId)
				.HasColumnName("mangaid")
				.IsRequired();

			builder.HasOne(mt => mt.Tag)
				.WithMany(t => t.Mangas)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_tag_mangatags");
			
			builder.HasOne(mt => mt.Manga)
				.WithMany(t => t.Tags)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_manga_mangatags");
		}
	}
}