using NuGet.Common;

namespace FindYourInfluencer.Helper
{
    public class APIResponseModel<T>
    { 
        public bool Success { get; set; } 
        public string Message { get; set; } 
        public string Token { get; set; } 
        public T Data { get; set; }
        public APIResponseModel(bool success, string message, string token = "", T data = default)
        {
            Success = success;
            Message = message;
            Data = data;
            Token = token;
        }
    }

}
