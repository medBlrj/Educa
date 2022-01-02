using Educa.Entities.QuestionsEntities;
using Educa.Helper.GenericResponseModels;
using Educa.Models.RequestModels;
using Educa.Repository.Entities.QuestionsEntities.Enum;
using Educa.Repository.QuestionsRepo;
using Educa.Repository.SubjectRepo;
using Educa.Services.QuestionsServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Educa.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase 
    {
        private readonly IQuestionsRepository questionsRepository;
       // private readonly IQuestionsServices questionServices;
        private readonly ISubjectRepository subjectRepository;
        
        public QuestionController(IQuestionsRepository questionsRepository , ISubjectRepository subjectRepository)
        {
            this.questionsRepository = questionsRepository;
            this.subjectRepository = subjectRepository;  
        }


        // GET: api/<QuestionsController>/bysupjectid/5/1/10
        [HttpGet("bysupjectid/{Id}/{pageNumber}/{pageSize}")]
        public IActionResult GetGetQuestionsBySubjectId(string Id, int pageNumber, int pageSize)
        {
            var idGuid = new Guid(Id);
            if (!subjectRepository.SubjectExist(idGuid))
            {
                return NotFound(new ApiResponse<string>(false, "Subject not Found", " No subject with this Id"));
            }

            var questions = questionsRepository.GetAllQuestionsBySupjectId(pageNumber, pageSize, idGuid);
            if (questions.RowCount == 0)
            {
                return NotFound(new ApiResponse<String>(false, "Question Not Found", "No Question In this Subject"));
            }

            return Ok(new ApiResponse<PagedResult<Question>>(true, "quesTions", questions));
        }
        // GET: api/<QuestionsController>/all
        [HttpGet("all/{pageNumber}/{pageSize}")]
        public IActionResult GetQuestions(int pageNumber, int pageSize)
        {
            var questions = questionsRepository.GetQuestions(pageNumber, pageSize);
            if (questions.RowCount == 0)
            {
                return NotFound(new ApiResponse<Question>(false, "Not Found", null));
            }
            return Ok(new ApiResponse<PagedResult<Question>>(true, "quesTions", questions));
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public IActionResult GetGetQuestionsById(Guid id)
        {
           
            var question = questionsRepository.GetQuestionsById(id);
            if (question == null)
            {
                return NotFound(new ApiResponse<Question>(false, "Question Not Found", null));
            }

            return Ok(new ApiResponse<Question>(true, "Question", question));
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public IActionResult Post([FromBody] QuestionRequest value)
        {
            if (!subjectRepository.SubjectExist(value.SubjectId))
            {
                return NotFound(new ApiResponse<string>(false, "Subject not Found", " No subject with this Id"));
            } 

            var question = new Question
            {
                QuestionId = Guid.NewGuid(),
                QNumber = value.QuestionNumber,
                Description = value.Question,      
                CorrectAnswer = value.CorrectAnswer,
                PossibleAnswers = value.PossibleAnswers,
                Type = (QuestionsType)value.QuestionType,   
                SubjectId = value.SubjectId,
                IsPublished = true,
                CreatedAt = DateTimeOffset.UtcNow,
                ModifiedAt = DateTimeOffset.UtcNow,

            };
            var questionId = questionsRepository.AddQuestion(question);
            return CreatedAtAction("Post", new ApiResponse<Guid>(true, "question added ssuccessfully", questionId));
        }

        // PUT api/<QuestionsController>/ispulished/{id}
        [HttpPut("ispulished/{id}")]
        public IActionResult IsPublished(string id)
        {
            var guidId = new Guid(id);
            var question = questionsRepository.GetQuestionsById(guidId);
            if (question == null)
                return NotFound(new ApiResponse<Question>(false, "level Not Found", null));

            if (question.IsPublished)
                question.IsPublished = false;
          

            var Id = questionsRepository.update(question);
            return Ok(new ApiResponse<Guid>(true, "update successfully", Id));
        }


        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            if (!questionsRepository.QuestionExist(id))
            {
              //  return NotFound(new ApiResponse<Guid>(true, " question not found", id));
            }
        }
    }
}
