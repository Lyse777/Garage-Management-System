using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Garage_Management_System.Pages
{
    public class LoginModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == Email);

            if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.Password))
            {
                // Logic for successful login
                // Redirect based on user role
                return RedirectToPage(user.RoleName == "Admin" ? "/Admin/Index" : "/Manager/Index");
            }

            // If we got this far, something failed, redisplay form
            ErrorMessage = "Invalid login attempt. Make sure you are Authorize";
            return Page();
        }

    }
}


