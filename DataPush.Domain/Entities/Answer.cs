using System.ComponentModel.DataAnnotations.Schema;

namespace DataPush.Domain.Entities;

public class Answer : BaseEntity
{
    public string Message { get; set; }
    public Guid QuestionId { get; set; }

    public Question Question { get; set; }
}