namespace Educa.Models.RequestModels
{
    public class SubjectsRequest
    {
        public string? shortDescription { get; set; }
        public string? SubjectName { get; set; }
        public string? LongDescription { get; set; }

        public IList<LQuestions>? Questions { get; set; } 

    }

    public class LQuestions {
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? PossibleAnswers { get; set; }
        public int QuestionType { get; set; }
    }
}
