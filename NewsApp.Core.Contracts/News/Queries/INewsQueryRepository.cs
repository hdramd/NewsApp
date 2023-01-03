﻿using NewsApp.Core.Contracts.News.Queries.GetByCategoryIdPagedList;
using NewsApp.Core.Contracts.News.Queries.GetNewsByBusinessId;
using NewsApp.Core.Contracts.News.Queries.Models;
using Zamin.Core.Contracts.Data.Queries;

namespace NewsApp.Core.Contracts.News.Queries
{
	public interface INewsQueryRepository
	{
		Task<NewsDto> GetByIdAsync(GetNewsByBusinessIdQuery query);
		Task<PagedData<NewsDto>> GetByCategoryIdPagedListAsync(GetByCategoryIdPagedListQuery query);
	}
}
