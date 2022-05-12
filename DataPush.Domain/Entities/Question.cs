namespace DataPush.Domain.Entities;

public class Question : BaseEntity
{
    public Question(string message, Guid userId)
    {
        Message = message;
        UserId = userId;
    }

    public string Message { get; set; }
    public Guid UserId { get; set; }

    public User User { get; set; }
    private readonly List<Answer> _answers = new();
    public IReadOnlyCollection<Answer> Answers => _answers;

    public void Update(string message)
    {
        Message = message;
    }
}