using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using System.Net;
using System.Diagnostics;

namespace WebApiEmpRegistry.exceptionHandlers
{
    public class CommonExceptionHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            //var st = new StackTrace(Thread.CurrentThread, true); // Diagnostics purposes
            var responseMessage = context.Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError, 
                context.Exception.Message);
            context.Result = new ResponseMessageResult(responseMessage);
            return Task.FromResult(context);
        }
    }
}