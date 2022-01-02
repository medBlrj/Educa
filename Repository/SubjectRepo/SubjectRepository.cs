using Educa.Entities.QuestionsEntities;
using Educa.Entities.SubjectsEntities;
using Microsoft.EntityFrameworkCore;

namespace Educa.Repository.SubjectRepo
{
    public class SubjectRepository : ISubjectRepository

    {
        private readonly EducoDbContext educoDbContext;
        public SubjectRepository(EducoDbContext educoDbContext)
        {
            this.educoDbContext = educoDbContext;
        }

        public Guid UpdateSubject(Subject subjects)
        {
            educoDbContext.Subjects.Update(subjects);
            educoDbContext.SaveChanges();
            return subjects.SubjectId;
        }

        public Guid AddSubject(Subject subjects)
        {
            educoDbContext.Subjects.Add(subjects);
            educoDbContext.SaveChanges();
            return subjects.SubjectId;
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return educoDbContext.Subjects;
        }

        public PagedResult<Subject> GetSubjects(int page, int pageSize)
        {
            return educoDbContext.Subjects.OrderBy(q => q.SubjectId).GetPaged(page, pageSize);

        }

        public Subject? GetSubjectsById(Guid Id)
        {
            return educoDbContext.Subjects.FirstOrDefault(q => q.SubjectId == Id);
        }

        public bool SubjectExist(Guid Id)
        {
           return educoDbContext.Subjects.Any(q => q.SubjectId == Id);  
        }

        public PagedResult<Subject> GetAllSubjectsByLevelId(int page, int pageSize, Guid LevelId)
        {
            return educoDbContext.Subjects.Where(s => s.LevelId == LevelId).OrderBy(s => s.SubjectId).GetPaged(page, pageSize);

        }
    }
}
