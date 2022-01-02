using Educa.Entities.LevelEntities;
using Educa.Entities.SubjectsEntities;
using Educa.Helper.GenericResponseModels;
using Educa.Models.RequestModels;
using Educa.Repository.LevelRepo;
using Educa.Repository.SubjectRepo;
using Microsoft.AspNetCore.Mvc;


namespace Educa.Controllers
{
    [Route("api/Level")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelRepository levelRepository;
        private readonly ISubjectRepository subjectRepository;
        public LevelController(ILevelRepository levelRepository, ISubjectRepository subjectRepository)
        {
            this.levelRepository = levelRepository;
            this.subjectRepository = subjectRepository;
        }

        // GET: api/<LevelController>
        [HttpGet("all/{pageNumber}/{pageSize}")]
        public IActionResult GetAll(int pageNumber, int pageSize)
        {
            var Levels = levelRepository.GetLevel(pageNumber, pageSize);
            if (Levels.RowCount == 0)
            {
                return NotFound(new ApiResponse<Level>(false, "Not Found", null));
            }
            return Ok(new ApiResponse<PagedResult<Level>>(true, "Levels", Levels));
        }


        // GET api/<LevelController>/5
        [HttpGet("{id}")]
       public IActionResult GetLevelById(Guid id)
        {

            var level = levelRepository.GetLevelById(id);
            if (level == null)
            {
                return NotFound(new ApiResponse<Level>(false, "level Not Found", null));
            }

            return Ok(new ApiResponse<Level>(true, "Question", level));
        }

        // POST api/<LevelController>
        [HttpPost]
        public IActionResult AddLevel([FromBody] LevelsRequest value)
        {
            
            // Add the Level
            var level = new Level
            {
                LevelId = Guid.NewGuid(),
                ShortDescription = value.shortDescription,
                LongDescription = value.LongDescription,
                LevelName = value.LevelName,
                IsPublished = true,
                CreatedAt = DateTimeOffset.UtcNow,
                ModifiedAt = DateTimeOffset.UtcNow,

            };
            var levelId = levelRepository.AddLevel(level);
            if (value.Subjects == null)
            {
                return Ok(levelId);
            }
            else
            {
                // Add subjects
                foreach (var subjects in value.Subjects)
                {
                    var subject = new Subject
                    {
                        LevelId = levelId,
                        Level = level,
                        SubjectId = Guid.NewGuid(),
                        SubjectName = subjects.SubjectName,
                        ShortDescription = subjects.shortDescription,
                        LongDescription = subjects.LongDescription,
                        IsPublished = true ,
                        CreatedAt = DateTimeOffset.UtcNow,
                        ModifiedAt = DateTimeOffset.UtcNow,

                    };
                    var subjectId = subjectRepository.AddSubject(subject);
                    level.Subjects.Add(subject);

                }
                var sd = levelRepository.UpdateLevel(level);
                return Ok(levelId);

            }
        }

        // PUT api/<LevelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPut("ispulished/{id}")]
        public IActionResult IsPublished(string id)
        {
            var guidId = new Guid(id);
            var level = levelRepository.GetLevelById(guidId);
            if (level == null)
                return NotFound(new ApiResponse<Subject>(false, "level Not Found", null));

            if (level.IsPublished)
                level.IsPublished = false;
           

            var sd = levelRepository.UpdateLevel(level);
            return Ok(new ApiResponse<Guid>(true, "update successfully", sd));
        }

        // DELETE api/<LevelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
