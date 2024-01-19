using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using books.Data;
using books.Models;

namespace books.Controllers
{
    public class ClientBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientBooks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClientBooks.Include(c => c.Book).Include(c => c.Client);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClientBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientBooks == null)
            {
                return NotFound();
            }

            var clientBook = await _context.ClientBooks
                .Include(c => c.Book)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientBook == null)
            {
                return NotFound();
            }

            return View(clientBook);
        }

        // GET: ClientBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName");
            return View();
        }

        // POST: ClientBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,BookId")] ClientBook clientBook)
        {
            
                _context.Add(clientBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", clientBook.BookId);

            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName", clientBook.ClientId);
            return View(clientBook);
        }

        // GET: ClientBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientBooks == null)
            {
                return NotFound();
            }

            var clientBook = await _context.ClientBooks.FindAsync(id);
            if (clientBook == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", clientBook.BookId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName", clientBook.ClientId);
            return View(clientBook);
        }

        // POST: ClientBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,BookId")] ClientBook clientBook)
        {
            if (id != clientBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientBookExists(clientBook.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", clientBook.BookId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName", clientBook.ClientId);
            return View(clientBook);
        }

        // GET: ClientBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientBooks == null)
            {
                return NotFound();
            }

            var clientBook = await _context.ClientBooks
                .Include(c => c.Book)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientBook == null)
            {
                return NotFound();
            }

            return View(clientBook);
        }

        // POST: ClientBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientBooks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ClientBooks'  is null.");
            }
            var clientBook = await _context.ClientBooks.FindAsync(id);
            if (clientBook != null)
            {
                _context.ClientBooks.Remove(clientBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientBookExists(int id)
        {
          return (_context.ClientBooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
