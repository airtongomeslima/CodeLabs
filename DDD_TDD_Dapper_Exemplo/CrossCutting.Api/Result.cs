namespace API.CrossCutting.Api
{
    public class Result<T>
    {
        public T Value { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
