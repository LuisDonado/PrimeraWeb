using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrimeraWeb.Data;
using PrimeraWeb.Models;

namespace PrimeraWeb.Pages.Users
{
    public class CreateModel : PageModel
    {
		private readonly SupermarketContext _context;

		public CreateModel(SupermarketContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]

		public User User { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Users == null || User == null)
			{
				return Page();
			}

			_context.Users.Add(User);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");

		}
	}
}
