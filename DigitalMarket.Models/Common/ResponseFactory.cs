namespace DigitalMarket.Models.Common
{
    public static class ResponseFactory
    {
        public static BaseResponse Success(string message) => new BaseResponse
        {
            IsSuccess = true,
            Message = message
        };

        public static BaseResponse<T> Success<T>(T data, string message = null) => new BaseResponse<T>
        {
            IsSuccess = true,
            Message = message,
            Data = data
        };

        public static BaseResponse Error(string message) => new BaseResponse
        {
            Message = message
        };

        public static BaseResponse<T> Error<T>(string message, T data = default) => new BaseResponse<T>
        {
            Message = message,
            Data = data
        };
    }
}