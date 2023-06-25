using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPages.Proj.Models;

namespace RazorPages.Proj.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Categoria
    public async Task<IActionResult> Index()
    {
        return _context.Categories != null ?
                    View(await _context.Categories.ToListAsync()) :
                    Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
    }

    [HttpGet]
    public IActionResult AddOrEdit(int id = 0)
    {
        if (id == 0) //cria
            return View(new Category());
        else //edita
            return View(_context.Categories.Find(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddOrEdit(Category category)
    {
        if (ModelState.IsValid)
        {
            if (category.Id == 0) //Cria
                _context.Add(category);
            else //Edita
                _context.Update(category);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    // POST: Categoria-Deletar
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Categories == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
        }
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

