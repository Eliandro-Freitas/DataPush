using DataPush.Domain.Commands;
using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;

namespace DataPush.Domain.Service;

public class ForumService
{
    private static IForumRepository _forumRepository;

    public ForumService(IForumRepository forumRepository)
       => _forumRepository = forumRepository;

    public Question CreateQuestion(CreateQuestionCommand command)
    {
        var question = new Question(command.Message, command.UserId);
        _forumRepository.Save(question);
        return question;
    }

    public async Task<Answer> CreateAnswer(CreateAnswerCommand command)
    {
        var question = await _forumRepository.GetQuestion(command.QuestionId);
        if (question is null) return null;

        var answer = new Answer(command.Message, command.QuestionId);
        _forumRepository.Save(answer);
        return answer;
    }
}