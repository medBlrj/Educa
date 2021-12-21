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

        public Guid UpdateSubject(Subjects subjects)
        {
            educoDbContext.Subjects.Update(subjects);
            educoDbContext.SaveChanges();
            return subjects.SubjectId;
        }

        public Guid AddSubject(Subjects subjects)
        {
            educoDbContext.Subjects.Add(subjects);
            educoDbContext.SaveChanges();
            return subjects.SubjectId;
        }

        public IEnumerable<Subjects> GetAllSubjects()
        {
            return educoDbContext.Subjects;
        }

        public PagedResult<Subjects> GetSubjects(int page, int pageSize)
        {
            return educoDbContext.Subjects.Include(x => x.Questions).OrderBy(q => q.SubjectId).GetPaged(page, pageSize);

        }

        public Subjects? GetSubjectsById(Guid Id)
        {
            return educoDbContext.Subjects.FirstOrDefault(q => q.SubjectId == Id);
        }

        public bool SubjectExist(Guid Id)
        {
           return educoDbContext.Subjects.Any(q => q.SubjectId == Id);  
        }
    }
}
