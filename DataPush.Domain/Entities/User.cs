namespace DataPush.Domain.Entities;

public class User : BaseEntity
{
    public User(string name, string document, string password, string email)
    {
        Name = name;
        Document = document;
        Password = password;
        Email = email;
    }

    public string Name { get; set; }
    public string Document { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    private readonly List<Question> _questions = new();
    public IReadOnlyCollection<Question> Questions => _questions;
}