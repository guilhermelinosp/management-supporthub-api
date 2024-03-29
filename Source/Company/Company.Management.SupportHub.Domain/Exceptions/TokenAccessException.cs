namespace Company.Management.SupportHub.Domain.Exceptions;

[Serializable]
public class TokenAccessException : SystemException
{
	public TokenAccessException()
	{
	}

	public TokenAccessException(string? messages)
	{
		Messages = messages;
	}

	public string? Messages { get; set; }
}