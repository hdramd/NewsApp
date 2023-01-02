using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApp.Core.Domain.News.Entities;

namespace NewsApp.Infra.Data.Sql.Commands.News.Config
{
    public class NewsCategoryMappingConfiguration : IEntityTypeConfiguration<NewsCategoryMapping>
    {
        public void Configure(EntityTypeBuilder<NewsCategoryMapping> builder)
        {
            builder.Property(x => x.NewsId)
                 .IsRequired();

            builder.Property(x => x.CategoryId)
                 .IsRequired();

            builder.HasOne(x => x.News)
                .WithMany(x => x.NewsCategoryMappings).HasForeignKey(x => x.NewsId);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.NewsCategoryMappings).HasForeignKey(x => x.CategoryId);
        }
    }
}
