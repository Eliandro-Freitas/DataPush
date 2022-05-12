using AutoMapper;
using DataPush.Domain.Commands;
using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using DataPush.Domain.Results;
using DataPush.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace DataPush.Api.Controllers
{
    public class ForumController : Controller
    {
        private readonly ForumService _forumService;
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ForumController(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository;
            _forumService = new ForumService(forumRepository);
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("v1/forum/questions")]
        public IActionResult PostQuestion([FromBody] CreateQuestionCommand command)
        {
            var question = _forumService.CreateQuestion(command);
            return Ok($"Pergunta salva ({question.Id})");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("v1/forum/{questionId:guid}/answers")]
        public async Task<IActionResult> PostAnswer(
            Guid questionId,
            [FromBody] CreateAnswerCommand command)
        {
            command.QuestionId = questionId;
            var answer = await _forumService.CreateAnswer(command);
            if (answer is null) return BadRequest();

            return Ok($"Resposta salva ({answer.Id})");
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QuestionResult[]))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("v1/forum/questions")]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _forumRepository.GetQuestions();
            var result = _mapper.Map<QuestionResult>(questions);
            return Ok(result);
        }
    }
}