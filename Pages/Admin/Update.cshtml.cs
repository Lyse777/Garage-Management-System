using Garage_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Garage_Management_System.Pages.Admin
{
    public class UpdateModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public UpdateModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == User.Id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            // Hash the new password if it has been changed
            if (!string.IsNullOrEmpty(User.Password))
            {
                userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(User.Password);
            }

            // Update the rest of the properties
            userToUpdate.Names = User.Names;
            userToUpdate.Gender = User.Gender;
            userToUpdate.Location = User.Location;
            userToUpdate.Email = User.Email;
            userToUpdate.RoleName = User.RoleName;

            _context.Attach(userToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}