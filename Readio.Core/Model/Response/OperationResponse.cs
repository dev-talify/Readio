using System.Net;

namespace Readio.Core.Model.Response;

public class OperationResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }

    public static OperationResponse<T> Success(T data, string message, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new OperationResponse<T>()
        {
            Data = data,
            Message = message,
            StatusCode = statusCode
        };
    }
}

public class OperationResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }

    public static OperationResponse Success(string message,HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new OperationResponse()
        {
            Message = message,
            StatusCode = statusCode
        };
    }


}