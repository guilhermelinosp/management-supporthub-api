using System.Net;
using Management.SupportHub.Domain.DTOs.Messages;
using Management.SupportHub.Domain.DTOs.Responses;
using Management.SupportHub.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Management.SupportHub.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		Console.WriteLine(context.Exception);

		if (context.Exception is DefaultException exception)
			context.Result = new ObjectResult(new
			{
				data = new ResponseException
				{
					Mensagens = exception.ErrorMessages!.ToList()
				}
			})
			{
				StatusCode = (int)HttpStatusCode.BadRequest
			};
		else
			context.Result =
				new ObjectResult(new
				{
					data = new ResponseException
					{
						Mensagens = [MessageException.ERRO_DESCONHECIDO]
					}
				})
				{
					StatusCode = (int)HttpStatusCode.InternalServerError
				};
	}
}