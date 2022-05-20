namespace DataPush.Domain.Entities;

public class Question : BaseEntity
{
    public Question(string message, string title, Guid userId)
    {
        UserId = userId;
        Title = title;
        Message = message;
    }

    public string Message { get; set; }
    public string Title { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public User User { get; set; }
    private readonly List<Answer> _answers = new();
    public IReadOnlyCollection<Answer> Answers => _answers;

    public void Update(string title, string message)
    {
        Title = title;
        Message = message;
    }
}