using Educa.Entities.courseEntities;
using Educa.Entities.SubjectsEntities;
using System.ComponentModel.DataAnnotations;

namespace Educa.Entities.LevelEntities
{
    public class Level : RootObject
    {
        [Key]
        public Guid LevelId { get; set; }

        [Required]
        [MaxLength(100)]
        public string LevelName { get; set; }

        [MaxLength(1000)]
        public string? ShortDescription { get; set; }

        [MaxLength(1000)]
        public string? LongDescription { get; set; }
        public IList<Subject>? Subjects { get; set; }
        public IList<Course>? Courses { get; set; }

    }
}
