using KR.Data;
using KR.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KR.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TodoController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(await _context.TodoItems
                .Where(t => t.UserId == user.Id)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                todoItem.UserId = user.Id;
                _context.Add(todoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var todoItem = await _context.TodoItems
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);

            if (todoItem == null)
            {
                return NotFound();
            }
            return View(todoItem);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsCompleted")] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);
                    var existingItem = await _context.TodoItems
                        .FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);

                    if (existingItem == null)
                    {
                        return NotFound();
                    }

                    existingItem.Title = todoItem.Title;
                    existingItem.Description = todoItem.Description;
                    existingItem.IsCompleted = todoItem.IsCompleted;

                    _context.Update(existingItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemExists(todoItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var todoItem = await _context.TodoItems
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // POST: Todo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var todoItem = await _context.TodoItems
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);

            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TodoItemExists(int id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
