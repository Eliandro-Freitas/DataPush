namespace DataPush.Domain.Results
{
    public class QuestionResult 
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public record Answer(Guid Id, string Message);
    };
}