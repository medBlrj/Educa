using Educa.Entities.courseEntities;

namespace Educa.Repository.CoursesRepo
{
    public interface ICourseRepository
    {
        Guid AddCourse(Course course);
        Course? GetCourseById(Guid Id);
        IEnumerable<Course> GetAllCourse();
        Guid UpdateCourse(Course course);
        bool CourseExist(Guid Id);
        PagedResult<Course> GetCourses(int page, int pageSize);
    }
}
