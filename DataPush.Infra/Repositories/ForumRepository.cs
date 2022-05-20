using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using DataPush.Domain.Results;
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

    public async Task<QuestionResult> GetQuestionResult(Guid Id)
    {
        var answerResult = _context.Set<Answer>().Select(x => new QuestionResult.Answer(x.Id, x.Message, x.Date)).ToList();
        return await
            (from question in _context.Set<Question>().AsNoTracking()
             join answer in _context.Set<Answer>() on question.Id equals answer.QuestionId
             join user in _context.Set<User>() on question.UserId equals user.Id
             where Id.Equals(question.Id)
             select new QuestionResult
             {
                 Id = question.Id,
                 Title = question.Title,
                 Message = question.Message,
                 Date = question.Date,
                 UserName = user.Name,
                 Answers = answerResult ?? null
             })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<QuestionResult>> GetQuestionsResult()
    {
        return await
            (from question in _context.Set<Question>().AsNoTracking()
             join user in _context.Set<User>() on question.UserId equals user.Id
             group question by new
             {
                 question.Id,
                 question.Title,
                 question.Message,
                 question.Date,
                 user.Name
             }
             into grouped
             select new QuestionResult
             {
                 Id = grouped.Key.Id,
                 Title = grouped.Key.Title,
                 Message = grouped.Key.Message,
                 Date = grouped.Key.Date,
                 UserName = grouped.Key.Name,
                 Answers = _context.Set<Answer>()
                    .Where(x => grouped.Key.Id.Equals(x.QuestionId))
                    .Select(x =>
                        new QuestionResult.Answer(
                            x.Id,
                            x.Message,
                            x.Date))
                    .ToArray()
             })
            .ToArrayAsync();
    }

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