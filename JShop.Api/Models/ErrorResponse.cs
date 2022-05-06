using System.Text.Json;

namespace JShop.Api.Models
{
    internal class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public List<string> Errors { get; set; }

        public ErrorResponse(int errorCode, List<string> errors)
        {
            ErrorCode = errorCode;
            Errors = errors;
        }

        public ErrorResponse(int errorCode, string error)
        {
            ErrorCode = errorCode;
            Errors = new List<string> { error };
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize<ErrorResponse>(this, new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
    }
}
