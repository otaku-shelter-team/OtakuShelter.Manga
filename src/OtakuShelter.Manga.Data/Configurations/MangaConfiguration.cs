using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Manga
{
	public class MangaConfiguration : IEntityTypeConfiguration<Manga>
	{
		public void Configure(EntityTypeBuilder<Manga> builder)
		{
			builder.ToTable("mangas");
			
			builder.Property(m => m.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(m => m.Title)
				.HasColumnName("title")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(m => m.Description)
				.HasColumnName("description")
				.HasMaxLength(2000)
				.IsRequired();

			builder.Property(m => m.Image)
				.HasColumnName("image")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(m => m.TypeId)
				.HasColumnName("typeid")
				.IsRequired();
			
			builder.HasOne(m => m.Type)
				.WithMany(t => t.Mangas)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_type_mangas");
		}
	}
}