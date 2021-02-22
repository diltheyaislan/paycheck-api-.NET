using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PaycheckAPI.Infrastructure.Errors.Exceptions
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

				public void OnActionExecuting(ActionExecutingContext context) { }

				public void OnActionExecuted(ActionExecutedContext context)
				{
						if (context.Exception is AppException exception)
						{
								context.Result = new ObjectResult(new ErrorResponse(exception))
								{
										StatusCode = (int) exception.Status,
								};
								context.ExceptionHandled = true;
						}
				}
    }
}