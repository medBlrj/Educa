using Educa.Entities.LevelEntities;
using Educa.Entities.QuestionsEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educa.Entities.SubjectsEntities
{
    public class Subject : RootObject
    {
        [Key]
        public Guid SubjectId { get; set; }
       
        [Required]
        [MaxLength(100)]
        public string SubjectName { get; set; }
        
        [MaxLength(1000)]
        public string? ShortDescription { get; set; }
        
        [MaxLength(1000)]
        public string? LongDescription { get; set; }
        public IList<Question>? Questions { get; protected set; } = new List<Question>();

        [ForeignKey("LevelId")]
        public Level Level { get; set; }
        public Guid LevelId { get; set; }

    }
}
