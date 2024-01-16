namespace Management.SupportHub.Domain.Exceptions;

[Serializable]
public class ForbiddenAccessException : SystemException
{
	public ForbiddenAccessException()
	{
	}

	public ForbiddenAccessException(string? messages)
	{
		Messages = messages;
	}

	public string? Messages { get; set; }
}