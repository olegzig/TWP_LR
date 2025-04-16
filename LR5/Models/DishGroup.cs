namespace LR5.Models
{
    public class DishGroup
    {
        public int DishGroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public List<Dish> Dishes { get; set; } = new();
    }
}
