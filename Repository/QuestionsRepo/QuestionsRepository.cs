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

        public Guid AddQuestion(Question questions) {

            educoDbContext.Questions.Add(questions);
            educoDbContext.SaveChanges();
            return questions.QuestionId;
            
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return educoDbContext.Questions;
        }

        public PagedResult<Question> GetAllQuestionsBySupjectId(int page, int pageSize , Guid subjectId)
        {
            return educoDbContext.Questions.Where(q => q.SubjectId == subjectId).OrderBy(q => q.QuestionId).GetPaged(page, pageSize);
        }

        public PagedResult<Question> GetQuestions(int page, int pageSize)
        {
            return educoDbContext.Questions.OrderBy(q => q.QuestionId ).GetPaged(page, pageSize);
        }

        public Question? GetQuestionsById(Guid Id)
        {
            return educoDbContext.Questions.FirstOrDefault(q => q.QuestionId == Id); 
        }

        public bool QuestionExist(Guid Id)
        {
            return educoDbContext.Questions.Any(q => q.QuestionId == Id);

        }

        public Guid update(Question questions)
        {
           educoDbContext.Questions.Update(questions);
            educoDbContext.SaveChanges();
            return questions.QuestionId;
        }
    }
}
