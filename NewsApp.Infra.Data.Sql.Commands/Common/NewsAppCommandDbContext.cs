using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Domain.Categories.Entities;
using System.Reflection;
using Zamin.Extensions.Events.Outbox.Dal.EF;
using Entities = NewsApp.Core.Domain.News.Entities;

namespace NewsApp.Infra.Data.Sql.Commands.Common
{
    public class NewsAppCommandDbContext : BaseOutboxCommandDbContext
    {
        #region DbSet
        public DbSet<Entities.News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        #region Ctor
        public NewsAppCommandDbContext(DbContextOptions<NewsAppCommandDbContext> options)
            : base(options)
        {
        }
        #endregion

        #region Configure
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
