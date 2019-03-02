using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Mangas
{
	public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
	{
		public void Configure(EntityTypeBuilder<Bookmark> builder)
		{
			builder.ToTable("bookmarks");

			builder.Property(b => b.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(b => b.AccountId)
				.HasColumnName("account_id")
				.IsRequired();

			builder.Property(b => b.Name)
				.HasColumnName("name")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(b => b.Created)
				.HasColumnName("created")
				.IsRequired();

			builder.Property(b => b.MangaId)
				.HasColumnName("manga_id")
				.IsRequired();

			builder.HasOne(b => b.Manga)
				.WithMany(m => m.Bookmarks)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_manga_bookmarks");

			builder.Property(b => b.ChapterId)
				.HasColumnName("chapter_id");

			builder.HasOne(b => b.Chapter)
				.WithMany(m => m.Bookmarks)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_chapter_bookmarks");

			builder.Property(b => b.PageId)
				.HasColumnName("page_id");

			builder.HasOne(b => b.Page)
				.WithMany(m => m.Bookmarks)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_page_bookmarks");

			builder.HasIndex(b => new { b.AccountId, b.MangaId, b.ChapterId, b.PageId })
				.IsUnique()
				.HasFilter(null)
				.HasName("UQ_accountid_mangaid_chapterid_pageid");
		}
	}
}