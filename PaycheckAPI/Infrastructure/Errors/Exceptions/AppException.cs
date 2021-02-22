using System;
using System.Net;

namespace PaycheckAPI.Infrastructure.Errors.Exceptions
{
    public class AppException : Exception
		{
			public HttpStatusCode Status { get; private set; }

			public AppException(HttpStatusCode status, string msg) : base(msg)
			{
					Status = status;
			}
    }
}