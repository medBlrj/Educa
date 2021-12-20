namespace Educa.Models.RequestModels
{
    public class QuestionRequest
    {
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? PossibleAnswers { get; set; }
        public int QuestionType { get; set; }
        public Guid SubjectId { get; set; }
    }
}
