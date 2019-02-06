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

			builder.Property(p => p.PageUrl)
				.HasColumnName("page_url")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(p => p.ChapterId)
				.HasColumnName("chapter_id")
				.IsRequired();
			
			builder.HasOne(c => c.Chapter)
				.WithMany(x => x.Pages)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_chapter_pages");
		}
	}
}