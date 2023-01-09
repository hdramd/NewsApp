using Microsoft.AspNetCore.Components;

namespace NewsApp.Endpoints.Shared.Components
{
    public partial class ErrorMessage
    {
        [Parameter]
        public string Message { get; set; }
    }
}
