using LR5.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Diagnostics;

namespace LR5.Controllers
{
    public class HomeController : Controller
    {
        private List<ListDemo> _listDemo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _listDemo = new List<ListDemo> {
                new ListDemo{ ListItemValue=1, ListItemText="Item 1"},
                new ListDemo{ ListItemValue=2, ListItemText="Item 2"}, 
                new ListDemo{ ListItemValue=3, ListItemText="Item 3"} 
            };
        }

        public IActionResult Index()
        {
            ViewData["Lst"] = new SelectList(_listDemo, "ListItemValue", "ListItemText");
            ViewData["Text"] = "Лабараторная работа 2";
            return View();
        }
    }

    public class ListDemo
    {
        public int ListItemValue { get; set; }
        public string ListItemText { get; set; }
    }
}