namespace Company.Management.SupportHub.Application.Services.Cryptography;

public interface ICryptographyService
{
	string EncryptPassword(string password);
	bool VerifyPassword(string password, string hashedPassword);
}