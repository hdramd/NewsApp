using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewsApp.Endpoints.Shared.Models
{
    public class ApiResult
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }

        public static ApiResult Successfull() => new() { Succeeded = true };

        public static ApiResult<TData> Successfull<TData>(TData data)
        {
            return new ApiResult<TData>
            {
                Succeeded = true,
                Data = data
            };
        }

        public static ApiResult Failed(string errorMessage) => new() { ErrorMessage = errorMessage };

        public static ApiResult<TData> Failed<TData>(string errorMessage)
        {
            return new ApiResult<TData>
            {
                Succeeded = false,
                ErrorMessage = errorMessage
            };
        }

    }

    public class ApiResult<TData>
    {
        public TData Data { get; set; }
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
