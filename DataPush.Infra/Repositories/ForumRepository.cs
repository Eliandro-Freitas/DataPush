using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra.Repositories;

public class ForumRepository : IForumRepository
{
    private readonly ApplicationContext _context;

    public ForumRepository(ApplicationContext context)
        => _context = context;

    public void DeleteAnswer(Guid id)
    {
        var answer = _context.Set<Answer>().FirstOrDefault(x => id.Equals(x.Id));
        _context.Remove(answer);
        _context.SaveChanges();
    }

    public void DeleteQuestion(Guid id)
    {
        var answers = _context.Set<Answer>().Where(x => id.Equals(x.QuestionId)).ToArray();
        _context.RemoveRange(answers);

        var question = _context.Set<Question>().FirstOrDefault(x => id.Equals(x.Id));
        _context.Remove(question);
        _context.SaveChanges();
    }

    public async Task<Answer> GetAnswer(Guid id)
        => await _context.Set<Answer>().FirstOrDefaultAsync(x => id.Equals(x.Id));

    public async Task<IEnumerable<Answer>> GetAnswerByQuestionId(Guid id)
        => await _context.Set<Answer>().Where(x => id.Equals(x.QuestionId)).ToArrayAsync();

    public async Task<IEnumerable<Answer>> GetAnswers()
        => await _context.Set<Answer>().ToArrayAsync();

    public async Task<Answer> GetAnswersByQuestionId(Guid id)
        => await _context.Set<Answer>().FirstOrDefaultAsync(x => id.Equals(x.QuestionId));

    public async Task<Question> GetQuestion(Guid Id)
        => await _context.Set<Question>().FirstOrDefaultAsync(x => Id.Equals(x.Id));

    public async Task<IEnumerable<Question>> GetQuestions()
        => await _context.Set<Question>().Include(x => x.Answers).ToArrayAsync();

    public void Save(Question question)
    {
        _context.Set<Question>().Add(question);
        _context.SaveChanges();
    }

    public void Save(Answer answer)
    {
        _context.Set<Answer>().Add(answer);
        _context.SaveChanges();
    }

    public void UpdateAnswer(Answer answer)
    {
        _context.Set<Answer>().Update(answer);
        _context.SaveChanges();
    }

    public void UpdateQuestion(Question question)
    {
        _context.Set<Question>().Update(question);
        _context.SaveChanges();
    }
}