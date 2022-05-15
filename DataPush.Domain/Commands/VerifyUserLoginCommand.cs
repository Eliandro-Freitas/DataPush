namespace DataPush.Domain.Commands;

public record VerifyUserLoginCommand(string Email, string Password);