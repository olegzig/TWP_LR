using System.ComponentModel.DataAnnotations;

namespace KR.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
