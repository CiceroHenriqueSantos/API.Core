namespace API.CoreSystem.Manager.Domain.API
{
    public class ApiResult<T> where T : new()
    {
        public ApiResult()
        {
            Errors = new List<string>();
        }
        public ApiResult(T data) : this()
        {
            Data = data;
            Errors = new List<string>();
        }
        public ApiResult(List<string> errors) : this()
        {
            Errors = errors ?? new List<string>();
        }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public bool Success { get { return Errors.Count == 0; } }
    }
}
