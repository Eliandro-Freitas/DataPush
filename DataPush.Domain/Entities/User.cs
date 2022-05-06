using System.ComponentModel.DataAnnotations.Schema;

namespace DataPush.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Document { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    private readonly List<Question> _questions = new();
    public IReadOnlyCollection<Question> Questions => _questions;
}