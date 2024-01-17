using System.Net;
using Company.Management.SupportHub.Domain.DTOs.Messages;
using Company.Management.SupportHub.Domain.DTOs.Responses;
using Company.Management.SupportHub.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Company.Management.SupportHub.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		Console.WriteLine(context.Exception);

		switch (context.Exception)
		{
			case DefaultException exception:
				HandleDefaultException(context, exception);
				break;
			case ForbiddenAccessException _:
				HandleForbiddenAccessException(context);
				break;
			case TokenAccessException _:
				HandleTokenAccessException(context);
				break;
			default:
				HandleUnknownException(context);
				break;
		}
	}


	private static void HandleDefaultException(ExceptionContext context, DefaultException exception)
	{
		context.Result = new ObjectResult(new
		{
			data = new ResponseException
			{
				Mensagens = exception.Messages!.ToList()
			}
		})
		{
			StatusCode = (int)HttpStatusCode.BadRequest
		};
	}

	private static void HandleForbiddenAccessException(ExceptionContext context)
	{
		context.Result = new ObjectResult(new
		{
			data = new ResponseException
			{
				Mensagens = [MessageExceptions.FORBIDDEN_ACCESS]
			}
		})
		{
			StatusCode = (int)HttpStatusCode.Forbidden
		};
	}

	private static void HandleTokenAccessException(ExceptionContext context)
	{
		context.Result = new ObjectResult(new
		{
			data = new ResponseException
			{
				Mensagens = [MessageExceptions.TOKEN_EXPIDED]
			}
		})
		{
			StatusCode = (int)HttpStatusCode.Unauthorized
		};
	}

	private static void HandleUnknownException(ExceptionContext context)
	{
		context.Result = new ObjectResult(new
		{
			data = new ResponseException
			{
				Mensagens = [MessageExceptions.UNKNOWN_ERROR]
			}
		})
		{
			StatusCode = (int)HttpStatusCode.InternalServerError
		};
	}
}