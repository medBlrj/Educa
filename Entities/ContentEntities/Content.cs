using Educa.Entities.courseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educa.Entities.ContentEntities
{
    public class Content :RootObject
    {
       [Key]
       public Guid ContentId { get; set; }
      
       [MaxLength(100)]
       public string Description { get; set; }
       
        [MaxLength(1000)]
       public string? LongDescription { get; set; }
       
       
       [ForeignKey("CourseId")]
       public Guid CourseId { get; set; }
       public Course Courses { get; set; }
    }
}
