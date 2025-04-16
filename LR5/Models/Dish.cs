namespace LR5.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Calories { get; set; }
        public string? Image { get; set; }
        public string? MimeType { get; set; }
        public int DishGroupId { get; set; }
        public DishGroup? Group { get; set; }
    }
}
