using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage_Management_System.Pages.Manager.ServicesManage
{
    public class DeleteModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public DeleteModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Services Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = await _context.Services.FirstOrDefaultAsync(m => m.Service_Id == id);

            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Service = await _context.Services.FindAsync(id);

            if (Service != null)
            {
                _context.Services.Remove(Service);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
