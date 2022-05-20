namespace DataPush.Domain.Commands;

public class UpdateQuestionCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
}