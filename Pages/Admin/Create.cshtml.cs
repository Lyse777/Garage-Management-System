using Garage_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Garage_Management_System.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public CreateModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Encrypt the password before saving
            User.Password = BCrypt.Net.BCrypt.HashPassword(User.Password);

            try
            {
                _context.Users.Add(User);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. The user was modified or deleted by another process.");
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

