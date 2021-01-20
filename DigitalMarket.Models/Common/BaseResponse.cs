namespace DigitalMarket.Models.Common
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }

    public class BaseResponse<TData> : BaseResponse
    {
        public TData Data { get; set; }
    }
}
