using Educa.Entities.QuestionsEntities;
using Educa.Entities.SubjectsEntities;

namespace Educa.Repository.SubjectRepo
{
    public interface ISubjectRepository
    {
  
            Guid AddSubject(Subjects subjects);
            Guid AddQuestionSubject(Subjects subjects);
            
            Subjects? GetSubjectsById(Guid Id);
            IEnumerable<Subjects> GetAllSubjects();
            PagedResult<Subjects> GetSubjects(int page, int pageSize);


    }
}

