namespace DataPush.Domain.Results
{
    public record QuestionResult(
        Guid Id,
        string Message,
        IEnumerable<QuestionResult.Answer> Answers) 
    {
        public record Answer(Guid Id, string Message);
    };
}