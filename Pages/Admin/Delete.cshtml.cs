using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using Microsoft.EntityFrameworkCore; 
using System.Threading.Tasks;

namespace Garage_Management_System.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public DeleteModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Id == 0)
            {
                return NotFound();
            }

            var userToDelete = await _context.Users.FindAsync(User.Id);

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }

}
