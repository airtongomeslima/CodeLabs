using Microsoft.AspNetCore.Mvc;

namespace API.CrossCutting.Api
{
    public static class HttpResult<T>
    {
        public static Result<T> Result { get; set; }

        public static IActionResult Success(T value)
        {
            Result = new Result<T>()
            {
                Value = value
            };

            return new ObjectResult(Result);
        }

        public static IActionResult Error(int code, string error)
        {
            Result = new Result<T>()
            {
                ErrorCode = code,
                ErrorMessage = error
            };

            return new ObjectResult(Result);
        }
    }
}