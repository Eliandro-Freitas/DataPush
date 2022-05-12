namespace DataPush.Domain.Commands;

public record CreateAnswerCommand(string Message) 
{
    public Guid QuestionId { get; set; }
};