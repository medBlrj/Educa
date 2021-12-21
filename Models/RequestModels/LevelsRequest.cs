namespace Educa.Models.RequestModels
{
    public class LevelsRequest
    {
        public string LevelName { get; set;}
        public string? shortDescription { get; set; }
        public string? LongDescription { get; set; }

        public IList<SubjectsList>? Subjects { get; set; }



    }
    public class SubjectsList
    {
        public string? SubjectName { get; set; }
        public string? shortDescription { get; set; }
        public string? LongDescription { get; set; }
    }
}

