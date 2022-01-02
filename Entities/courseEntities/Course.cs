using Educa.Entities.LevelEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educa.Entities.courseEntities
{
    public class Course : RootObject
    {
       [Key]
       public Guid CourseId { get; set; }
        
       [Required]
       [StringLength(50)]
       public String Title { get; set; }
        
       public TimeSpan EstimatedTime{ get; set; }
       
       [ForeignKey("LevelId")]
       public Level Levels { get; set; }
       public Guid LevelId { get; set; }

    }
}
