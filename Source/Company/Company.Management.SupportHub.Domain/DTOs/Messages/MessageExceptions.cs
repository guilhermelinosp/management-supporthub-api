namespace Company.Management.SupportHub.Domain.DTOs.Messages;

public record MessageExceptions
{
	public static string UNKNOWN_ERROR => "unknown error";
	public static string TOKEN_EXPIDED => "token expired";
	public static string TOKEN_NOT_PROVIDED => "token not provided";
	public static string FORBIDDEN_ACCESS => "forbidden access";
}