using LR5.Models;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly List<Dish> _dishes;
    private readonly List<DishGroup> _dishGroups;

    public ProductController()
    {
        _dishGroups = new List<DishGroup>
        {
            new DishGroup { DishGroupId = 1, GroupName = "Стартеры" },
            new DishGroup { DishGroupId = 2, GroupName = "Основные блюда" }
        };

        _dishes = new List<Dish>
        {
            new Dish { DishId = 1, DishName = "Суп-харчо", Calories = 200, DishGroupId = 1, Image = "soup.jpg" },
            new Dish { DishId = 2, DishName = "Борщ", Calories = 300, DishGroupId = 1, Image = "borscht.jpg" }
        };
    }

    public IActionResult Index()
    {
        return View(_dishes);
    }
}