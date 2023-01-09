using NewsApp.Endpoints.Shared.Models;
using Refit;
namespace NewsApp.Endpoints.Shared.Services
{
    public class ServiceBase
    {
        protected static async Task<ApiResult> FailedResult(ApiException ex)
        {
            var errors = await ex.GetContentAsAsync<string[]>();
            return ApiResult.Failed(errors.First());
        } 
        
        protected static async Task<ApiResult<TData>> FailedResult<TData>(ApiException ex)
        {
            var errors = await ex.GetContentAsAsync<string[]>();
            return ApiResult.Failed<TData>(errors.First());
        }
    }
}