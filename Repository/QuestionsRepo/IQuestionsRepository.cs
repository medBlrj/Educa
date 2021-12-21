using Educa.Entities.QuestionsEntities;
using Educa.Repository.Entities;
using Educa.Helper.GenericResponseModels;
namespace Educa.Repository.QuestionsRepo
{
    public interface IQuestionsRepository
    {
       Guid AddQuestion(Questions questions);
       Questions? GetQuestionsById(Guid Id);
       IEnumerable<Questions> GetAllQuestions();
       bool QuestionExist(Guid Id);  
       PagedResult<Questions> GetQuestions(int page, int pageSize);


    }
}
