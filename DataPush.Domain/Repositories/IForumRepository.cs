using DataPush.Domain.Entities;

namespace DataPush.Domain.Repositories;

public interface IForumRepository
{
    void Save(Question question);
    void UpdateQuestion(Question question);
    void DeleteQuestion(Guid id);
    Task<Question> GetQuestion(Guid Id);
    Task<IEnumerable<Question>> GetQuestions();

    void Save(Answer answer);
    void UpdateAnswer(Answer answer);
    void DeleteAnswer(Guid id);
    Task<IEnumerable<Answer>> GetAnswers();
    Task<IEnumerable<Answer>> GetAnswerByQuestionId(Guid id);
    Task<Answer> GetAnswersByQuestionId(Guid id);
    Task<Answer> GetAnswer(Guid id);
}