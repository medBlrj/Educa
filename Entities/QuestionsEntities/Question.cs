using Educa.Entities.ContentEntities;
using Educa.Entities.SubjectsEntities;
using Educa.Repository.Entities.QuestionsEntities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educa.Entities.QuestionsEntities
{
    public class Question : RootObject
    {
        [Key]
        public Guid QuestionId { get; set; }
        [Required]
        public int QNumber { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
        [MaxLength(1000)]
        public string? CorrectAnswer { get; set; }
        [MaxLength(1000)]
        public string? PossibleAnswers { get; set; }
        [Required]
        public QuestionsType Type { get; set; }
        
        [ForeignKey("SubjectId")]
        public Subject Subjects { get; set; }
        public Guid SubjectId { get; set; }

        [ForeignKey("ContentId")]
        public Content? Content { get; set; }
        public Guid? ContentId { get; set; }
    }
}
