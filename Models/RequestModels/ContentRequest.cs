namespace Educa.Models.RequestModels
{
    public class ContentRequest
    {
        public string Description { get; set; }
        public string? LongDescription { get; set; }
        public Guid CourseId { get; set; }


    }
}
