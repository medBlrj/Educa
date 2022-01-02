using System.ComponentModel.DataAnnotations;

namespace Educa.Entities
{
    public class RootObject
    {
        [Required]
        public bool IsPublished { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }
        [Required]
        public DateTimeOffset ModifiedAt { get; set; }


    }
}
