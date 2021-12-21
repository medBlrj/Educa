using Educa.Entities.QuestionsEntities;
using Educa.Entities.SubjectsEntities;
using Educa.Helper.GenericResponseModels;
using Educa.Models.RequestModels;
using Educa.Repository.Entities.QuestionsEntities.Enum;
using Educa.Repository.LevelRepo;
using Educa.Repository.QuestionsRepo;
using Educa.Repository.SubjectRepo;
using Microsoft.AspNetCore.Mvc;


namespace Educa.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IQuestionsRepository questionsRepository;
        private readonly ILevelRepository levelRepository;
        private readonly ISubjectRepository subjectRepository;
        public SubjectsController(IQuestionsRepository questionsRepository , ISubjectRepository subjectRepository )
        {
            this.questionsRepository = questionsRepository;
            this.subjectRepository = subjectRepository;
        }

        // GET: api/<SubjectsController>
        [HttpGet("{id}")]
        public IActionResult GetSubjectById(Guid id)
        {

            var subject = subjectRepository.GetSubjectsById(id);
            if (subject == null)
            {
                return NotFound(new ApiResponse<Subjects>(false, "subject Not Found", null));
            }

            return Ok(new ApiResponse<Subjects>(true, "subjects", subject));
        }

        // GET api/<SubjectsController>/5
        [HttpGet("all/{pageNumber}/{pageSize}")]
        public IActionResult Get(int pageNumber , int pageSize)
        {
            var subjects = subjectRepository.GetSubjects(pageNumber, pageSize);
            if (subjects.RowCount == 0)
            {
                return NotFound(new ApiResponse<Subjects>(false, "Not Found", null));
            }
            return Ok(new ApiResponse<PagedResult<Subjects>>(true, "Products", subjects));
        }

        // POST api/<SubjectsController>
        [HttpPost]
        public IActionResult AddSubjects([FromBody] SubjectsRequest value)
        {
            if (!levelRepository.LevelExist(value.LevelId))
                return NotFound(new ApiResponse<string>(false, "not Found"," Enter existing LevelID" ));

            // Add the subject
            var subject = new Subjects
            {
                SubjectId =Guid.NewGuid(),
                ShortDescription =  value.shortDescription ,
                LongDescription = value.LongDescription,
                SubjectName = value.SubjectName ,
                LevelId = value.LevelId,
            };
            var subjectid = subjectRepository.AddSubject(subject);
            if (value.Questions == null)
            {
                return Ok(subjectid);
            }else
            {
                // Add question with in Subjects
                foreach (var Question in value.Questions)
                {
                    var question = new Questions
                    {
                        SubjectId = subjectid,
                        QuestionId = Guid.NewGuid(),
                        QNumber = Question.QuestionNumber,
                        CorrectAnswer = Question.CorrectAnswer,
                        PossibleAnswers = Question.PossibleAnswers,
                        Type = (QuestionsType)Question.QuestionType,
                        Question = Question.Question
                    };
                    var questionId = questionsRepository.AddQuestion(question);
                    subject.Questions.Add(question);

                }
                var sd = subjectRepository.UpdateSubject(subject);
                return Ok(subjectid);
            }
            

        }

        // PUT api/<SubjectsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
