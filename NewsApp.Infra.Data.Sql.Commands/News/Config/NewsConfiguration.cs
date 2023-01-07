using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NewsEntity = NewsApp.Core.Domain.News.Entities.News;

namespace NewsApp.Infra.Data.Sql.Commands.News.Config
{
    public class NewsConfiguration : IEntityTypeConfiguration<NewsEntity>
    {
        public void Configure(EntityTypeBuilder<NewsEntity> builder)
        {
            builder.Property(x => x.Titr)
                .IsRequired().HasMaxLength(200);

            builder.HasIndex(x => x.Titr)
                .IsUnique();
        }
    }
}
