using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Mangas
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
				.HasMaxLength(100)
				.IsRequired();
			
			builder.HasIndex(t => t.Name)
				.IsUnique()
				.HasName("ux_types_name");
		}
	}
}