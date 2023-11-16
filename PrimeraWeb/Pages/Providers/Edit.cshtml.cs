using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrimeraWeb.Data;
using PrimeraWeb.Models;

namespace PrimeraWeb.Pages.Providers
{
    public class EditModel : PageModel
    {
        private readonly SupermarketContext _context;

        public EditModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Provider Provider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);
            if (provider == null)
            {
                return NotFound();
            }
            Provider = provider;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Provider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvidersExists(Provider.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return RedirectToPage("./index");
        }

        private bool ProvidersExists(int id)
        {
            return (_context.Providers?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}
