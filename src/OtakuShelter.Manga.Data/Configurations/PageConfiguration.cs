using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Manga
{
	public class PageConfiguration : IEntityTypeConfiguration<Page>
	{
		public void Configure(EntityTypeBuilder<Page> builder)
		{
			builder.ToTable("pages");

			builder.Property(p => p.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(p => p.Order)
				.HasColumnName("order")
				.IsRequired();

			builder.HasIndex(p => new {p.ChapterId, p.Order})
				.IsUnique()
				.HasName("UQ_chapterid_order");

			builder.Property(p => p.Image)
				.HasColumnName("image")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(p => p.ChapterId)
				.HasColumnName("chapterid")
				.IsRequired();
			
			builder.HasOne(c => c.Chapter)
				.WithMany(x => x.Pages)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_chapter_pages");
		}
	}
}