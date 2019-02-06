using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Manga
{
	public class TypeConfiguration : IEntityTypeConfiguration<Type>
	{
		public void Configure(EntityTypeBuilder<Type> builder)
		{
			builder.ToTable("types");

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