using Educa.Entities.QuestionsEntities;
using System.Threading.Tasks;


namespace Educa.Services.QuestionsServices
{
    public interface IQuestionsServices
    {
        Task<IEnumerable<Questions>> ListAsync();


    }
}
