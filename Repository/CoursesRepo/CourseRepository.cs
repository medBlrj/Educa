using Educa.Entities.courseEntities;
using Microsoft.EntityFrameworkCore;

namespace Educa.Repository.CoursesRepo
{
    public class CourseRepository : ICourseRepository
    {
        private readonly EducoDbContext educoDbContext;
        public CourseRepository(EducoDbContext educoDbContext)
        {
            this.educoDbContext = educoDbContext;
        }

        public Guid AddCourse(Course course)
        {
            educoDbContext.Courses.Add(course);
            educoDbContext.SaveChanges();
            return course.CourseId;
        }

        public bool CourseExist(Guid Id)
        {
            return educoDbContext.Courses.Any(c => c.CourseId == Id);
        }

        public IEnumerable<Course> GetAllCourse()
        {
            return educoDbContext.Courses;
        }

        public Course? GetCourseById(Guid Id)
        {
            return educoDbContext.Courses.FirstOrDefault(c => c.CourseId == Id);   
        }

        public PagedResult<Course> GetCourses(int page, int pageSize)
        {
           return educoDbContext.Courses.OrderBy(c =>c.CourseId).GetPaged(page, pageSize);
        }

        public Guid UpdateCourse(Course course)
        {
            educoDbContext.Courses.Update(course);
            educoDbContext.SaveChanges();
            return course.CourseId;
        }
    }
}
