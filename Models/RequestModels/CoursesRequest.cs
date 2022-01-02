namespace Educa.Models.RequestModels
{
    public class CoursesRequest
    {
       public String Title { get; set; }
       public string EstimatedTime { get; set; }
       public Guid LevelId { get; set; }
    }
}
