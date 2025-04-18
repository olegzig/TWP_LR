using System.ComponentModel.DataAnnotations;

namespace KR.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название необходимо")]
        [StringLength(100, ErrorMessage = "Максимум 100 символов")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Максимум 500 символов")]
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Создано")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Статус")]
        public bool IsCompleted { get; set; }

        [Display(Name = "ID пользователя")]
        public string UserId { get; set; } = string.Empty;
    }
}
