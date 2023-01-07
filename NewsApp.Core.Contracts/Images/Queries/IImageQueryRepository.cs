using NewsApp.Core.Contracts.Images.Queries.Models;

namespace NewsApp.Core.Contracts.Images.Queries
{
	public interface IImageQueryRepository
	{
		Task<List<ImageDto>> GetByIdAsync(List<long> ids);
	}
}
