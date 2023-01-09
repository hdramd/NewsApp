using NewsApp.Endpoints.Shared.Models;
using Refit;
using System.Net;

namespace NewsApp.Endpoints.Shared.Services
{
    public class ServiceBase
    {
        protected static async Task<ApiResult> FailedResult(ApiException ex)
        {
            string errorMessage = await ExtractErrorMessage(ex);
            return ApiResult.Failed(errorMessage);
        }

        protected static async Task<ApiResult<TData>> FailedResult<TData>(ApiException ex)
        {
            string errorMessage = await ExtractErrorMessage(ex);
            return ApiResult.Failed<TData>(errorMessage);
        }

        private static async Task<string> ExtractErrorMessage(ApiException ex)
        {
            string errorMessage = "An error has occurred.";
            if (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                var errors = await ex.GetContentAsAsync<string[]>();
                errorMessage = errors.First();
            }
            else if (ex.StatusCode == HttpStatusCode.InternalServerError)
            {
                var error = await ex.GetContentAsAsync<ApiServerError>();
                errorMessage = error.Title;
            }
            return errorMessage;
        }
    }
}