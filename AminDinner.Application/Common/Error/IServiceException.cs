
using System.Net;

namespace AminDinner.Application.Common.Error;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
