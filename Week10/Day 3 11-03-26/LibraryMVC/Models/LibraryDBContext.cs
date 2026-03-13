using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Models;

public partial class LibraryDBContext : DbContext
{
    public LibraryDBContext()
    {
    }

    public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SIDDHARTH\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Authors__70DAFC34324870DF");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C20741CC90C7");

            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasConstraintName("FK__Books__AuthorId__4CA06362");

            entity.HasMany(d => d.Borrowers).WithMany(p => p.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookBorrower",
                    r => r.HasOne<Borrower>().WithMany()
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookBorro__Borro__52593CB8"),
                    l => l.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookBorro__BookI__5165187F"),
                    j =>
                    {
                        j.HasKey("BookId", "BorrowerId").HasName("PK__BookBorr__58882FB2B0A98E93");
                        j.ToTable("BookBorrowers");
                    });
        });

        modelBuilder.Entity<Borrower>(entity =>
        {
            entity.HasKey(e => e.BorrowerId).HasName("PK__Borrower__568EDB573714AC27");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
