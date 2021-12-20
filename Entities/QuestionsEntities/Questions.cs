using Educa.Entities.SubjectsEntities;
using Educa.Repository.Entities.QuestionsEntities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educa.Entities.QuestionsEntities
{
    public class Questions
    {
        [Key]
        public Guid QuestionId { get; set; }
        [Required]
        public int QNumber { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? Question { get; set; }
        [MaxLength(1000)]
        public string? CorrectAnswer { get; set; }
        [MaxLength(1000)]
        public string? PossibleAnswers { get; set; }
        [Required]
        public QuestionsType Type { get; set; }
        
        [ForeignKey("SubjectId")]
        public Subjects Subjects { get; set; }
        public Guid SubjectId { get; set; }
    }
}
