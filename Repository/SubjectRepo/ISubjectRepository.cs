using Educa.Entities.QuestionsEntities;
using Educa.Entities.SubjectsEntities;

namespace Educa.Repository.SubjectRepo
{
    public interface ISubjectRepository
    {
  
            Guid AddSubject(Subject subjects);
            Guid UpdateSubject(Subject subjects);
            Subject? GetSubjectsById(Guid Id);
            IEnumerable<Subject> GetAllSubjects();
            PagedResult<Subject> GetAllSubjectsByLevelId(int page, int pageSize, Guid LevelId);
             bool SubjectExist(Guid Id);
            PagedResult<Subject> GetSubjects(int page, int pageSize);


    }
}

