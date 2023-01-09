namespace NewsApp.Endpoints.Shared.Models
{
    public class ApiResult
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
    } 
    
    public class ApiResult<TData>
    {
        public TData Data { get; set; }
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
