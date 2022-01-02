using Educa.Entities.courseEntities;
using Educa.Helper.GenericResponseModels;
using Educa.Models.RequestModels;
using Educa.Repository.CoursesRepo;
using Educa.Repository.LevelRepo;
using Microsoft.AspNetCore.Mvc;


namespace Educa.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        private readonly ILevelRepository levelRepository;

        public CoursesController(ICourseRepository courseRepository , ILevelRepository levelRepository)
        {
            this.courseRepository = courseRepository;
            this.levelRepository = levelRepository;    
        }

        // GET: api/<CoursesController>/all
        [HttpGet("all/{pageNumber}/{pageSize}")]
        public IActionResult GetAll(int pageNumber, int pageSize)
        {
            var courses = courseRepository.GetCourses(pageNumber, pageSize);
            if (courses.RowCount == 0)
            {
                return NotFound(new ApiResponse<Course>(false, "Not Found", null));
            }
            return Ok(new ApiResponse<PagedResult<Course>>(true, "courses", courses));
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public IActionResult GetCourseById(Guid id)
        {

            var course = courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound(new ApiResponse<Course>(false, "course Not Found", null));
            }

            return Ok(new ApiResponse<Course>(true, "course", course));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public IActionResult Post([FromBody] CoursesRequest value)
        {
            if (!levelRepository.LevelExist(value.LevelId))
            {
                return NotFound(new ApiResponse<string>(false, "Level not Found", " No Level with this Id"));
            }
            // Add course 
            var course = new Course
            {
                CourseId = Guid.NewGuid(),
                Title = value.Title,
                EstimatedTime = TimeSpan.Parse(value.EstimatedTime),
                CreatedAt = DateTimeOffset.UtcNow,
                ModifiedAt = DateTimeOffset.UtcNow,
                IsPublished = true,
                LevelId = value.LevelId,
            };

            var CourseId = courseRepository.AddCourse(course);
            return CreatedAtAction("Post", new ApiResponse<Guid>(true, "course added ssuccessfully", CourseId));
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE  api/<CoursesController>/5
        [HttpPut("ispulished/{id}")]
        public IActionResult IsPublished(string id)
        {
            var guidId = new Guid(id);
            var course = courseRepository.GetCourseById(guidId);
            if (course == null)
                return NotFound(new ApiResponse<Course>(false, "level Not Found", null));

            if (course.IsPublished)
                course.IsPublished = false;
           
            var sd = courseRepository.UpdateCourse(course);
            return Ok(new ApiResponse<Guid>(true, "update successfully", sd));
        }
    }
}
