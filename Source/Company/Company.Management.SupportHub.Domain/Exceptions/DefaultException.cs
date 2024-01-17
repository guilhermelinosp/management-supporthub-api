namespace Company.SupportHub.Domain.Exceptions;

[Serializable]
public class DefaultException : SystemException
{
	public DefaultException()
	{
	}

	public DefaultException(List<string>? messages)
	{
		Messages = messages;
	}

	public List<string>? Messages { get; set; }
}