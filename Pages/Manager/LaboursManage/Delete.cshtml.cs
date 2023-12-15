using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage_Management_System.Pages.Manager.LaboursManage
{
    public class DeleteModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public DeleteModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Labour Labour { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Labour = await _context.Labours.FirstOrDefaultAsync(m => m.LabourId == id);

            if (Labour == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Labour = await _context.Labours.FindAsync(id);

            if (Labour != null)
            {
                _context.Labours.Remove(Labour);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index"); // Redirect to the Index page
        }
    }
}
    
