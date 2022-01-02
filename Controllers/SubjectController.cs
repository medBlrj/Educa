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
    public class SubjectController : ControllerBase
    {
        private readonly IQuestionsRepository questionsRepository;
        private readonly ILevelRepository levelRepository;
        private readonly ISubjectRepository subjectRepository;
        public SubjectController(IQuestionsRepository questionsRepository , ISubjectRepository subjectRepository , ILevelRepository levelRepository)
        {
            this.questionsRepository = questionsRepository;
            this.subjectRepository = subjectRepository;
            this.levelRepository = levelRepository;
        }


        // GET: api/<SubjectsController>/{id}/1/5
        [HttpGet("byLevelId/{Id}/{pageNumber}/{pageSize}")]
        public IActionResult GetSubjectbylevelId(string Id, int pageNumber, int pageSize)
        {
            var idGuid = new Guid(Id);
            if (!levelRepository.LevelExist(idGuid))
            {
                return NotFound(new ApiResponse<string>(false, "Level not Found", " No level found with this Id"));
            }

            var subjects = subjectRepository.GetAllSubjectsByLevelId(pageNumber , pageSize , idGuid);
            if (subjects.RowCount == 0)
            {
                return NotFound(new ApiResponse<String>(false, "subjects Not Found", "No subjects In this level"));
            }

            return Ok(new ApiResponse<PagedResult<Subject>>(true, "Subjects " , subjects));
        }

        // GET: api/<SubjectsController>
        [HttpGet("{id}")]
        public IActionResult GetSubjectById(Guid id)
        {

            var subject = subjectRepository.GetSubjectsById(id);
            if (subject == null)
            {
                return NotFound(new ApiResponse<Subject>(false, "subject Not Found", null));
            }

            return Ok(new ApiResponse<Subject>(true, "subjects", subject));
        }

        // GET api/<SubjectsController>/1/5
        [HttpGet("all/{pageNumber}/{pageSize}")]
        public IActionResult Get(int pageNumber , int pageSize)
        {
            var subjects = subjectRepository.GetSubjects(pageNumber, pageSize);
            if (subjects.RowCount == 0)
            {
                return NotFound(new ApiResponse<Subject>(false, "Not Found", null));
            }
            return Ok(new ApiResponse<PagedResult<Subject>>(true, "Products", subjects));
        }

        // POST api/<SubjectsController>
        [HttpPost]
        public IActionResult AddSubjects([FromBody] SubjectsRequest value)
        {
            if (!levelRepository.LevelExist(value.LevelId))
            {
                return NotFound(new ApiResponse<string>(false, "not Found", " Enter existing LevelID"));
            }
               

            // Add the subject
            var subject = new Subject
            {
                SubjectId =Guid.NewGuid(),
                ShortDescription =  value.shortDescription ,
                LongDescription = value.LongDescription,
                SubjectName = value.SubjectName ,
                LevelId = value.LevelId,
                IsPublished = true,
                CreatedAt = DateTimeOffset.UtcNow,
                ModifiedAt = DateTimeOffset.UtcNow,
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
                    var question = new Question
                    {
                        SubjectId = subjectid,
                        QuestionId = Guid.NewGuid(),
                        QNumber = Question.QuestionNumber,
                        CorrectAnswer = Question.CorrectAnswer,
                        PossibleAnswers = Question.PossibleAnswers,
                        Type = (QuestionsType)Question.QuestionType,
                        Description = Question.Question,
                        IsPublished = true,
                        CreatedAt = DateTimeOffset.UtcNow,
                        ModifiedAt = DateTimeOffset.UtcNow,
                    };
                    var questionId = questionsRepository.AddQuestion(question);
                    subject.Questions.Add(question);

                }
                var sd = subjectRepository.UpdateSubject(subject);
                return Ok(subjectid);
            }
            

        }

        // PUT api/<SubjectsController>/ispulished/<id>
        [HttpPut("ispulished/{id}")]
        public IActionResult IsPublished(string id)
        {
            var guidId = new Guid(id);
            var subject = subjectRepository.GetSubjectsById(guidId);
            if (subject == null)
                return NotFound(new ApiResponse<Subject>(false, "subject Not Found", null));

            if (subject.IsPublished)         
                subject.IsPublished = false;
            
             
            var sd = subjectRepository.UpdateSubject(subject);
            return Ok(new ApiResponse<Guid>(true, "update successfully", sd));
        }

        // DELETE api/<SubjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
