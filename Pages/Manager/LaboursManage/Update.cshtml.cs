using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage_Management_System.Pages.Manager.LaboursManage
{
    public class UpdateModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public UpdateModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Labour Labour { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Labour = await _context.Labours.FindAsync(id);

            if (Labour == null)
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

            _context.Attach(Labour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabourExists(Labour.LabourId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index"); // Assuming there's an Index page
        }

        private bool LabourExists(int id)
        {
            return _context.Labours.Any(e => e.LabourId == id);
        }
    }
}

