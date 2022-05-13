namespace DataPush.Domain.Commands;

public class UpdateAnswerCommand
{
    public Guid Id { get; set; }
    public string Message { get; set; }
}