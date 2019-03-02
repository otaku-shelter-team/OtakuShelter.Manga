using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Mangas
{
	public class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.ToTable("tags");

			builder.Property(t => t.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(t => t.Name)
				.HasColumnName("name")
				.HasMaxLength(50)
				.IsRequired();
		}
	}
}