using NewsApp.Core.Contracts.News.Queries.GetByCategoryIdPagedList;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.GetNewsPagedList;
using NewsApp.Core.Contracts.News.Queries.Models;
using System.Linq.Expressions;
using Zamin.Core.Contracts.Data.Queries;

namespace NewsApp.Core.Contracts.News.Queries
{
	public interface INewsQueryRepository
	{
		Task<NewsDto> GetByIdAsync(GetNewsByIdQuery query);
		Task<PagedData<NewsDto>> GetByCategoryIdPagedListAsync(GetByCategoryIdPagedListQuery query);
		Task<NewsDto> GetAsync(Expression<Func<NewsDto, bool>> predicate);
        Task<PagedData<NewsDto>> GetPagedListAsync(GetNewsPagedListQuery query);
    }
}
