using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace NewsApp.Infra.Data.Sql.Queries.Common
{
    public partial class NewAppQueryDbContext : BaseQueryDbContext
    {
        public NewAppQueryDbContext(DbContextOptions<NewAppQueryDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<OutBoxEventItem> OutBoxEventItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =.; Database = MiniBlogDb; User Id =sa; Password= 1qaz!QAZ; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).HasMaxLength(50);

                entity.Property(e => e.ModifiedByUserId).HasMaxLength(50);
            });

            modelBuilder.Entity<OutBoxEventItem>(entity =>
            {
                entity.Property(e => e.AccuredByUserId).HasMaxLength(255);

                entity.Property(e => e.AggregateName).HasMaxLength(255);

                entity.Property(e => e.AggregateTypeName).HasMaxLength(500);

                entity.Property(e => e.EventName).HasMaxLength(255);

                entity.Property(e => e.EventTypeName).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
