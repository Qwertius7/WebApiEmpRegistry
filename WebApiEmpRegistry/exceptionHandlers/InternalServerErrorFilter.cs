using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace WebApiEmpRegistry.exceptionHandlers
{
    public class InternalServerErrorFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            //var st = new StackTrace(Thread.CurrentThread, true); // Diagnostics purposes
            if (actionExecutedContext.Exception is Exception)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //var st = new StackTrace(Thread.CurrentThread, true); // Diagnostics purposes
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}