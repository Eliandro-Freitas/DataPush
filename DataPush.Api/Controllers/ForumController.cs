using DataPush.Domain.Commands;
using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using DataPush.Domain.Results;
using Microsoft.AspNetCore.Mvc;

namespace DataPush.Api.Controllers;

public class ForumController : Controller
{
    private readonly IForumRepository _forumRepository;

    public ForumController(IForumRepository forumRepository)
        => _forumRepository = forumRepository;

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("v1/forum/questions")]
    public IActionResult PostQuestion([FromBody] CreateQuestionCommand command)
    {
        var question = new Question(command.Message, command.Title, command.UserId);
        _forumRepository.Save(question);
        return Ok(question.Id);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("v1/forum/questions/{id:guid}")]
    public async Task<IActionResult> PutQuestion(Guid id, [FromBody] UpdateQuestionCommand command)
    {
        command.Id = id;
        var question = await _forumRepository.GetQuestion(id);
        question.Update(command.Title, command.Message);
        _forumRepository.UpdateQuestion(question);
        return Ok(question.Id);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("v1/forum/questions/{id:guid}")]
    public IActionResult DeleteQuestion(Guid id)
    {
        _forumRepository.DeleteQuestion(id);
        return Ok($"Mensagem deletada");
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QuestionResult[]))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("v1/forum/questions/{id:guid}")]
    public async Task<IActionResult> GetQuestion(Guid id)
    {
        var questions = await _forumRepository.GetQuestionResult(id);
        return Ok(questions);
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QuestionResult[]))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("v1/forum/questions")]
    public async Task<IActionResult> GetQuestions()
    {
        var questions = await _forumRepository.GetQuestionsResult();
        return Ok(questions);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("v1/forum/{questionId:guid}/answers")]
    public IActionResult PostAnswer(
        Guid questionId,
        [FromBody] CreateAnswerCommand command)
    {
        command.QuestionId = questionId;
        var answer = new Answer(command.Message, command.QuestionId);
        if (answer is null) return BadRequest();
        _forumRepository.Save(answer);
        return Ok(answer.Id);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("v1/forum/answers/{anserId:guid}")]
    public async Task<IActionResult> PutAnswer(Guid id, [FromBody] UpdateAnswerCommand command)
    {
        command.Id = id;
        var answer = await _forumRepository.GetAnswer(command.Id);
        answer.Update(command.Message);
        _forumRepository.UpdateAnswer(answer);
        if (answer is null) return BadRequest();

        return Ok(answer.Id);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("v1/forum/answers/{anserId:guid}")]
    public IActionResult DeleteAnswer(Guid id)
    {
        _forumRepository.DeleteAnswer(id);
        return Ok($"Resposta deletada");
    }
}