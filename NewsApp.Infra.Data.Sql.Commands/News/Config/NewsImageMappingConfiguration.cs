using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApp.Core.Domain.News.Entities;

namespace NewsApp.Infra.Data.Sql.Commands.News.Config
{
	public class NewsImageMappingConfiguration : IEntityTypeConfiguration<NewsImageMapping>
	{
		public void Configure(EntityTypeBuilder<NewsImageMapping> builder)
		{
			builder.Property(x => x.NewsId)
				.IsRequired();

			builder.Property(x => x.ImageId)
				 .IsRequired();

			builder.HasOne(x => x.News)
				.WithMany(x => x.NewsImageMappings).HasForeignKey(x => x.NewsId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
