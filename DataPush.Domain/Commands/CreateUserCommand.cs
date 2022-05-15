namespace DataPush.Domain.Commands;

public record CreateUserCommand(string Name, string Document, string Password, string Email);