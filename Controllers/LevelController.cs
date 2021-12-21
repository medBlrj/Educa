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
        public string Get(int id)
        {
            return "value";
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
                    var subject = new Subjects
                    {
                        LevelId = levelId,
                        Level = level,
                        SubjectId = Guid.NewGuid(),
                        SubjectName = subjects.SubjectName,
                        ShortDescription = subjects.shortDescription,
                        LongDescription = subjects.LongDescription,

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

        // DELETE api/<LevelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
