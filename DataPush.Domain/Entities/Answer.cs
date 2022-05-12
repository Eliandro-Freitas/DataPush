namespace DataPush.Domain.Entities;

public class Answer : BaseEntity
{
    public Answer(string message, Guid questionId)
    {
        Message = message;
        QuestionId = questionId;
    }

    public string Message { get; set; }
    public Guid QuestionId { get; set; }

    public Question Question { get; set; }

    public void Update(string message)
    {
        Message = message;
    }
}