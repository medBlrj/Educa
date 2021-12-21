using Educa.Entities.QuestionsEntities;
using Educa.Entities.SubjectsEntities;

namespace Educa.Repository.SubjectRepo
{
    public interface ISubjectRepository
    {
  
            Guid AddSubject(Subjects subjects);
            Guid UpdateSubject(Subjects subjects);
            Subjects? GetSubjectsById(Guid Id);
            IEnumerable<Subjects> GetAllSubjects();
            bool SubjectExist(Guid Id);
            PagedResult<Subjects> GetSubjects(int page, int pageSize);


    }
}

