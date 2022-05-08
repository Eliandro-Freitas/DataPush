namespace DataPush.Domain.Entities;

public class Question : BaseEntity
{
    public Question(string message)
    {
        Message = message;
    }

    public string Message { get; set; }

    private readonly List<User> _users = new();
    public IReadOnlyCollection<User> Users => _users;

    private readonly List<Answer> _answers = new();

    public IReadOnlyCollection<Answer> Answers => _answers;
}