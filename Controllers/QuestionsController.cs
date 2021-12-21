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
    public class QuestionsController : ControllerBase 
    {
        private readonly IQuestionsRepository questionsRepository;
        private readonly IQuestionsServices questionServices;
        private readonly ISubjectRepository subjectRepository;
        
        public QuestionsController(IQuestionsRepository questionsRepository , ISubjectRepository subjectRepository)
        {
            this.questionsRepository = questionsRepository;
            this.subjectRepository = subjectRepository;  
        }
              
         
        // GET: api/<QuestionsController>
        [HttpGet]
        public async Task<IEnumerable<Questions>> GetAllAsunc()
        {
            var questions = await questionServices.ListAsync();
            return questions;
        }

        [HttpGet("all/{pageNumber}/{pageSize}")]
        public IActionResult GetQuestions(int pageNumber, int pageSize)
        {
            var questions = questionsRepository.GetQuestions(pageNumber, pageSize);
            if (questions.RowCount == 0)
            {
                return NotFound(new ApiResponse<Questions>(false, "Not Found", null));
            }
            return Ok(new ApiResponse<PagedResult<Questions>>(true, "quesTions", questions));
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public IActionResult GetGetQuestionsById(Guid id)
        {
           
            var question = questionsRepository.GetQuestionsById(id);
            if (question == null)
            {
                return NotFound(new ApiResponse<Questions>(false, "Question Not Found", null));
            }

            return Ok(new ApiResponse<Questions>(true, "Question", question));
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public IActionResult Post([FromBody] QuestionRequest value)
        {
            if (!subjectRepository.SubjectExist(value.SubjectId))
            {
                return NotFound(new ApiResponse<string>(false, "not Found", " Enter existing subjectId"));
            } 

            var question = new Questions
            {
                QuestionId = Guid.NewGuid(),
                QNumber = value.QuestionNumber,
                Question = value.Question,      
                CorrectAnswer = value.CorrectAnswer,
                PossibleAnswers = value.PossibleAnswers,
                Type = (QuestionsType)value.QuestionType,   
                SubjectId = value.SubjectId,

            };
            var questionId = questionsRepository.AddQuestion(question);
            return CreatedAtAction("Post", new ApiResponse<Guid>(true, "question added ssuccessfully", questionId));
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
