using Educa.Entities.ContentEntities;
using Educa.Helper.GenericResponseModels;
using Educa.Models.RequestModels;
using Educa.Repository.ContenstRepo;
using Educa.Repository.CoursesRepo;
using Microsoft.AspNetCore.Mvc;


namespace Educa.Controllers
{
    [Route("api/content")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentRepository contentRepository;
        private readonly ICourseRepository courseRepository;
          public ContentController(IContentRepository contentRepository , ICourseRepository courseRepository) 
          {
            this.contentRepository = contentRepository;
            this.courseRepository = courseRepository;
          }



        // GET: api/<ContentController>
        [HttpGet("all/{pageNumber}/{pageSize}")]
        public IActionResult GetAll(int pageNumber, int pageSize)
        {
            var contents = contentRepository.GetContent(pageNumber, pageSize);
            if (contents.RowCount == 0)
            {
                return NotFound(new ApiResponse<Content>(false, "Not Found", null));
            }
            return Ok(new ApiResponse<PagedResult<Content>>(true, "courses", contents));
        }

        // GET api/<ContentController>/5
        [HttpGet("{id}")]
        public IActionResult GetCourseById(Guid id)
        {

            var content = contentRepository.GetContentById(id);
            if (content == null)
            {
                return NotFound(new ApiResponse<Content>(false, "content Not Found", null));
            }

            return Ok(new ApiResponse<Content>(true, "content", content));
        }

        // POST api/<ContentController>
        [HttpPost]
        public IActionResult Post([FromBody] ContentRequest value)
        {
            if (!courseRepository.CourseExist(value.CourseId))
            {
                return NotFound(new ApiResponse<string>(false, "course not Found", " No course with this Id"));
            }
            // Add course 
            var content = new Content
            {
               ContentId = Guid.NewGuid(),
               CourseId = value.CourseId,
               Description = value.Description,
               LongDescription = value.LongDescription,
               CreatedAt    = DateTimeOffset.UtcNow,
               ModifiedAt = DateTimeOffset.UtcNow,
               IsPublished = true
               
            };

            var contentId = contentRepository.AddContent(content);
            return CreatedAtAction("Post", new ApiResponse<Guid>(true, "course added ssuccessfully", contentId));
        }

        // PUT api/<ContentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContentController>/5
        [HttpPut("ispulished/{id}")]
        public IActionResult IsPublished(Guid id)
        {
            var content = contentRepository.GetContentById(id);
            if (content == null)
                return NotFound(new ApiResponse<Content>(false, "Content Not Found", null));

            if (content.IsPublished)
                content.IsPublished = false;

            var sd = contentRepository.UpdateContent(content);
            return Ok(new ApiResponse<Guid>(true, "update successfully", sd));
        }
    }
}
