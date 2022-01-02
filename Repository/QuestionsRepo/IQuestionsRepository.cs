using Educa.Entities.QuestionsEntities;
using Educa.Repository.Entities;
using Educa.Helper.GenericResponseModels;
namespace Educa.Repository.QuestionsRepo
{
    public interface IQuestionsRepository
    {
       Guid AddQuestion(Question questions);
       Guid update(Question questions);
       Question? GetQuestionsById(Guid Id);
       IEnumerable<Question> GetAllQuestions();
       PagedResult<Question> GetAllQuestionsBySupjectId(int page, int pageSize, Guid subjectId);
       bool QuestionExist(Guid Id);  
       PagedResult<Question> GetQuestions(int page, int pageSize);


    }
}
