using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Manga
{
	public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
	{
		public void Configure(EntityTypeBuilder<Chapter> builder)
		{
			builder.ToTable("chapters");

			builder.Property(c => c.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(c => c.Title)
				.HasColumnName("title")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(c => c.UploadDate)
				.HasColumnName("upload_date")
				.HasColumnType("date")
				.IsRequired();

			builder.Property(c => c.MangaId)
				.HasColumnName("manga_id")
				.IsRequired();
			
			builder.HasOne(m => m.Manga)
				.WithMany(t => t.Chapters)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_manga_chapters");
		}
	}
}