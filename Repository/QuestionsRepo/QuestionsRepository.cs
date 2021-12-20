using Educa.Entities.QuestionsEntities;
using Educa.Repository.Entities;

namespace Educa.Repository.QuestionsRepo
{
    public class QuestionsRepository : IQuestionsRepository 
    {
        private readonly EducoDbContext educoDbContext;
        public QuestionsRepository(EducoDbContext educoDbContext)
        {
            this.educoDbContext = educoDbContext;
        }

        public Guid AddQuestion(Questions questions) {

            educoDbContext.Questions.Add(questions);
            educoDbContext.SaveChanges();
            return questions.QuestionId;
            
        }

        public IEnumerable<Questions> GetAllQuestions()
        {
            return educoDbContext.Questions;
        }

        public PagedResult<Questions> GetQuestions(int page, int pageSize)
        {
            return educoDbContext.Questions.OrderBy(q => q.QuestionId ).GetPaged(page, pageSize);
        }

        public Questions? GetQuestionsById(Guid Id)
        {
            return educoDbContext.Questions.FirstOrDefault(q => q.QuestionId == Id); 
        }

}
}
