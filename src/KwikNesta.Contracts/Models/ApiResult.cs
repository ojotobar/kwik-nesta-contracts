namespace KwikNesta.Contracts.Models
{
    public class ApiResult<TResult>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public bool Successful { get; set; }
        public TResult? Data { get; set; }

        public ApiResult() { }

        public ApiResult(string message, 
                         int status)
        {
            Message = message;
            Status = status;
        }

        public ApiResult(TResult data,
                         string? message = null,
                         int status = 200,
                         bool successful = true)
        {
            Data = data;
            Status = status;
            Message = message;
            Successful = successful;
        }
    }
}