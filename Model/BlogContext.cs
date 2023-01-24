using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace react_red.Model;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostDownvote> PostDownvotes { get; set; }

    public virtual DbSet<PostUpvote> PostUpvotes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=Blog;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostsId).HasName("PK__Posts__AFCEE3222CC63F6A");

            entity.HasIndex(e => e.Slug, "UQ__Posts__BC7B5FB6BC7ECEEE").IsUnique();

            entity.Property(e => e.PostsId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.Header).HasMaxLength(500);
            entity.Property(e => e.Published)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("published");
            entity.Property(e => e.Slug)
                .HasMaxLength(450)
                .IsUnicode(false);

            entity.HasOne(d => d.Author).WithMany(p => p.Posts)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthorName");
        });

        modelBuilder.Entity<PostDownvote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostDown__3214EC07CF9727C0");

            entity.ToTable("PostDownvote");

            entity.HasOne(d => d.Post).WithMany(p => p.PostDownvotes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Down");

            entity.HasOne(d => d.User).WithMany(p => p.PostDownvotes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Down");
        });

        modelBuilder.Entity<PostUpvote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostUpvo__3214EC07A956AEFC");

            entity.ToTable("PostUpvote");

            entity.HasOne(d => d.Post).WithMany(p => p.PostUpvotes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post");

            entity.HasOne(d => d.User).WithMany(p => p.PostUpvotes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PK__Users__A349B0623FB15106");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105348214F38E").IsUnique();

            entity.Property(e => e.UsersId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Bio).HasColumnType("text");
            entity.Property(e => e.Email)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.Image).HasColumnType("image");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Registered)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Role)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasDefaultValueSql("('user')");
            entity.Property(e => e.Token)
                .HasColumnType("text")
                .HasColumnName("TOKEN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
