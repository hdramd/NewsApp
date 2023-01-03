using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace NewsApp.Infra.Data.Sql.Queries.Common;

public partial class NewsAppQueryDbContext : BaseQueryDbContext
{
	public NewsAppQueryDbContext(DbContextOptions<NewsAppQueryDbContext> options)
	: base(options)
	{
	}

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsCategoryMapping> NewsCategoryMappings { get; set; }

    public virtual DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }

    public virtual DbSet<ParrotTranslation> ParrotTranslations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server =.\\VE_SERVER; Database = NewsAppDb; User Id = sa; Password = 123; MultipleActiveResultSets = true; Encrypt = false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CreatedByUserId).HasMaxLength(50);
            entity.Property(e => e.ModifiedByUserId).HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.CreatedByUserId).HasMaxLength(50);
            entity.Property(e => e.ModifiedByUserId).HasMaxLength(50);
            entity.Property(e => e.Titr)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<NewsCategoryMapping>(entity =>
        {
            entity.ToTable("NewsCategoryMapping");

            entity.HasIndex(e => e.CategoryId, "IX_NewsCategoryMapping_CategoryId");

            entity.HasIndex(e => e.NewsId, "IX_NewsCategoryMapping_NewsId");

            entity.Property(e => e.CreatedByUserId).HasMaxLength(50);
            entity.Property(e => e.ModifiedByUserId).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.NewsCategoryMappings).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.News).WithMany(p => p.NewsCategoryMappings).HasForeignKey(d => d.NewsId);
        });

        modelBuilder.Entity<OutBoxEventItem>(entity =>
        {
            entity.ToTable("OutBoxEventItems", "zamin");

            entity.Property(e => e.AccuredByUserId)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.AggregateId).IsRequired();
            entity.Property(e => e.AggregateName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.AggregateTypeName)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.EventName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.EventPayload).IsRequired();
            entity.Property(e => e.EventTypeName)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.SpanId).HasMaxLength(100);
            entity.Property(e => e.TraceId).HasMaxLength(100);
        });

        modelBuilder.Entity<ParrotTranslation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ParrotTr__3214EC07DBAC8ACE");

            entity.HasIndex(e => e.BusinessId, "UQ__ParrotTr__F1EAA36FE24CE0A8").IsUnique();

            entity.Property(e => e.BusinessId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Culture).HasMaxLength(5);
            entity.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
