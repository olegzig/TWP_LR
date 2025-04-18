using System.ComponentModel.DataAnnotations;

namespace KR.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название необходимо")]
        [StringLength(100, ErrorMessage = "Максимум 100 символов")]
        public string Title { get; set; } = string.Empty; // Инициализация

        [StringLength(500, ErrorMessage = "Максимум 500 символов")]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
