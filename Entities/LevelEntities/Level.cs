using Educa.Entities.SubjectsEntities;
using System.ComponentModel.DataAnnotations;

namespace Educa.Entities.LevelEntities
{
    public class Level
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
        public IList<Subjects>? Subjects { get; set; }


    }
}
