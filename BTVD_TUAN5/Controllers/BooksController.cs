using BTVD_TUAN5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BTVD_TUAN5.Controllers;

public class BooksController : Controller
{
    private readonly DBcontext _context;

    public BooksController(DBcontext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _context.Books
            .AsNoTracking()
            .Include(b => b.Topic)
            .ToListAsync();

        var topics = await _context.Topics
            .AsNoTracking()
            .OrderBy(t => t.Name)
            .Select(t => new TopicCountViewModel
            {
                Name = t.Name,
                Count = t.Books.Count()
            })
            .ToListAsync();

        ViewBag.TopicCounts = topics;
        return View(books);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var book = await _context.Books.AsNoTracking().Include(b => b.Topic).FirstOrDefaultAsync(m => m.BookId == id);
        return book == null ? NotFound() : View(book);
    }

    public async Task<IActionResult> Create()
    {
        await PopulateTopicsDropDownList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (!await _context.Topics.AnyAsync(t => t.TopicId == book.TopicId))
        {
            ModelState.AddModelError(nameof(book.TopicId), "Chủ đề không hợp lệ.");
        }

        if (!ModelState.IsValid)
        {
            await PopulateTopicsDropDownList(book.TopicId);
            return View(book);
        }

        _context.Add(book);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();

        await PopulateTopicsDropDownList(book.TopicId);
        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Book book)
    {
        if (id != book.BookId) return NotFound();

        if (!await _context.Topics.AnyAsync(t => t.TopicId == book.TopicId))
        {
            ModelState.AddModelError(nameof(book.TopicId), "Chủ đề không hợp lệ.");
        }

        if (!ModelState.IsValid)
        {
            await PopulateTopicsDropDownList(book.TopicId);
            return View(book);
        }

        try
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookExists(book.BookId)) return NotFound();
            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var book = await _context.Books.AsNoTracking().Include(b => b.Topic).FirstOrDefaultAsync(m => m.BookId == id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool BookExists(int id) => _context.Books.Any(e => e.BookId == id);

    private async Task PopulateTopicsDropDownList(object? selectedTopic = null)
    {
        var topics = await _context.Topics.AsNoTracking().OrderBy(t => t.Name).ToListAsync();
        ViewBag.TopicId = new SelectList(topics, "TopicId", "Name", selectedTopic);
    }
}

public class TopicCountViewModel
{
    public string Name { get; set; } = string.Empty;
    public int Count { get; set; }
}
